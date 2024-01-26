namespace Application.Administration.Maintainer.Universes.Commands.ToggleUniverse;
public record ToggleUniverseCommand(int UniverseId) : IRequest;

public class ToggleUniverseCommandHandler(IApplicationDbContext context) : IRequestHandler<ToggleUniverseCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(ToggleUniverseCommand request, CancellationToken cancellationToken)
    {
        var universe = await _context.Universes.FindAsync(new object[] { request.UniverseId }, cancellationToken);

        Guard.Against.NotFound(request.UniverseId, universe);

        universe.ToggleActive();

        await _context.SaveChangesAsync(cancellationToken);

    }
}
