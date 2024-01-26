namespace Application.Administration.Maintainer.Universes.Queries.GetUniverseById;
public record GetUniverseByIdQuery(int UniverseId) : IRequest<UniverseVM>;

public class GetUniverseByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetUniverseByIdQuery, UniverseVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<UniverseVM> Handle(GetUniverseByIdQuery request, CancellationToken cancellationToken)
    {
        var universe = await _context.Universes
            .AsNoTracking()
            .ProjectTo<UniverseVM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.UniverseId == request.UniverseId, cancellationToken);

        Guard.Against.NotFound(request.UniverseId, universe);

        return universe;
    }
}

