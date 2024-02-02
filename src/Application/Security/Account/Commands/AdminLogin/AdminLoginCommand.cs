namespace Application.Security.Account.Commands.AdminLogin;

public record AdminLoginCommand(string UserName, string Password, string Supplanted) : IRequest<bool>;

public class AdminLoginRequestCommandHandler(IApplicationDbContext context) : IRequestHandler<AdminLoginCommand, bool>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<bool> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
    {
        var superAdmin = await _context.Users
                    .Include(x => x.UserRoles)
                    .Where(x => x.UserName == request.UserName && x.UserRoles.Any(ur => ur.Role.RoleName == "SuperAdmin") && x.IsActive)
                    .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.UserName, superAdmin);

        var user = await _context.Users
                .Where(x => x.UserName == request.Supplanted && x.IsActive)
                .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Supplanted, user);


        return true;
    }
}
