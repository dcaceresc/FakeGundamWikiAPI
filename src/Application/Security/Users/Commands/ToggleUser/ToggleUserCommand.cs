namespace Application.Security.Users.Commands.ToggleUser;
public record ToggleUserCommand(int UserId) : IRequest;

public class ToggleUserCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<ToggleUserCommand>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task Handle(ToggleUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _applicationDbContext.Users.FindAsync(new object[] { request.UserId }, cancellationToken);

        Guard.Against.NotFound(request.UserId, user);

        user.ToggleActive();

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}