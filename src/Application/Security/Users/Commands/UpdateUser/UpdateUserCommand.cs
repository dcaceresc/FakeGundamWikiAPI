namespace Application.Security.Users.Commands.UpdateUser;
public record UpdateUserCommand : IRequest
{
    public int UserId { get; init; }
    public string UserName { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public IList<int> RolesId { get; init; } = null!;

}

public class UpdateUserCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _applicationDbContext.Users.FindAsync(new object[] { request.UserId }, cancellationToken);

        Guard.Against.NotFound(request.UserId, user);

        user.Update(request.UserName, request.FirstName, request.LastName);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        var oldUserRoles = await _applicationDbContext.UserRoles.Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken);

        foreach (var item in request.RolesId)
        {
            var exitingUserRole = oldUserRoles.FirstOrDefault(x => x.RoleId == item);

            if (exitingUserRole is null)
            {
                var userRole = user.AssignRole(item);

                _applicationDbContext.UserRoles.Add(userRole);
            }
            else
            {
                exitingUserRole.LastModified = DateTime.Now;
            }
        }

        foreach (var userRole in oldUserRoles)
        {
            if (!request.RolesId.Contains(userRole.RoleId))
            {
                _applicationDbContext.UserRoles.Remove(userRole);
            }
        }

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}