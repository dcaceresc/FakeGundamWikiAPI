namespace Application.Administration.Maintainer.MobileSuits.Commands.ToggleMobileSuit;
public record ToggleMobileSuitCommand(int MobileSuitId) : IRequest;

public class ToggleMobileSuitCommandHandler(IApplicationDbContext context) : IRequestHandler<ToggleMobileSuitCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(ToggleMobileSuitCommand request, CancellationToken cancellationToken)
    {
        var mobileSuit = await _context.MobileSuits.FindAsync(new object[] {request.MobileSuitId},cancellationToken);

        Guard.Against.NotFound(request.MobileSuitId, mobileSuit);

        mobileSuit.ToggleActive();

        await _context.SaveChangesAsync(cancellationToken);

    }
}