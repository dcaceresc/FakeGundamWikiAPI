namespace Application.Administration.Security.Roles.Commands.CreateRole;
public record CreateRoleCommand(string RoleName) : IRequest<int>;

public class CreateRoleCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<CreateRoleCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = Role.Create(request.RoleName);

        _applicationDbContext.Roles.Add(role);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return role.RoleId;
    }
}