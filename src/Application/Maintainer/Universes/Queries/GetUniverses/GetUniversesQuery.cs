namespace Application.Maintainer.Universes.Queries.GetUniverses;
public record GetUniversesQuery : IRequest<IList<UniverseDto>>;

public class GetUniversesQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetUniversesQuery, IList<UniverseDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<UniverseDto>> Handle(GetUniversesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Universes
            .AsNoTracking()
            .ProjectTo<UniverseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
