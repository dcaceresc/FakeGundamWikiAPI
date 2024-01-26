namespace Application.Administration.Maintainer.Universes.Commands.CreateUniverse;
public record CreateUniverseCommand(string UniverseName) : IRequest<int>;

public class CreateUniverseCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateUniverseCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateUniverseCommand request, CancellationToken cancellationToken)
    {
        var universe = Universe.Create(request.UniverseName);

        _context.Universes.Add(universe);

        await _context.SaveChangesAsync(cancellationToken);

        return universe.UniverseId;
    }
}