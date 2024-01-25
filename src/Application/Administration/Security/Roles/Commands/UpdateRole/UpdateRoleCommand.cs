namespace Application.Administration.Security.Roles.Commands.UpdateRole;
public record UpdateRoleCommand(int RoleId, string RoleName) : IRequest;

public class UpdateRoleCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<UpdateRoleCommand>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _applicationDbContext.Roles.FindAsync(new object[] { request.RoleId }, cancellationToken);

        Guard.Against.NotFound(request.RoleId, role);

        role.ToggleActive();

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}