namespace Application.Security.Users.Commands.CreateUser;
public record CreateUserCommand : IRequest<int>
{
    public string UserName { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Password { get; init; } = null!;
    public IList<int> RoleIds { get; init; } = null!;
}


public class CreateUserCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<CreateUserCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.UserName, request.FirstName, request.LastName, request.Password);

        _applicationDbContext.Users.Add(user);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        foreach (var item in request.RoleIds)
        {
            var userRole = user.AssignRole(item);

            _applicationDbContext.UserRoles.Add(userRole);
        }

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return user.UserId;
    }
}