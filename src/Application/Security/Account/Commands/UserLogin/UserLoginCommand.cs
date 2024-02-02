namespace Application.Security.Account.Commands.UserLogin;

public record UserLoginCommand(string UserName, string Password) : IRequest<bool>;

public class LoginRequestCommandHandler(IApplicationDbContext context) : IRequestHandler<UserLoginCommand, bool>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<bool> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.UserName == request.UserName && x.Password == request.Password, cancellationToken);

        Guard.Against.NotFound(request.UserName, user);

        return true;
    }
}