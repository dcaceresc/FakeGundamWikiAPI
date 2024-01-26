namespace Application.Administration.Maintainer.Universes.Commands.UpdateUniverse;
public record UpdateUniverseCommand(int UniverseId, string UniverseName) : IRequest;

public class UpdateUniverseCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateUniverseCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateUniverseCommand request, CancellationToken cancellationToken)
    {
        var universe = await _context.Universes.FindAsync(new object[] { request.UniverseId }, cancellationToken);

        Guard.Against.NotFound(request.UniverseId, universe);

        universe.Update(request.UniverseName);

        await _context.SaveChangesAsync(cancellationToken);

    }
}

