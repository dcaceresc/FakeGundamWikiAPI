namespace Application.Administration.Security.Roles.Commands.ToggleRole;
public record ToggleRoleCommand(int RoleId) : IRequest;
public class ToggleRoleCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<ToggleRoleCommand>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task Handle(ToggleRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _applicationDbContext.Roles.FindAsync(new object[] { request.RoleId }, cancellationToken);

        Guard.Against.NotFound(request.RoleId, role);

        role.ToggleActive();

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
