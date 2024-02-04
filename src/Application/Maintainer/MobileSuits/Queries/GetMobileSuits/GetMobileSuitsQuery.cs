
namespace Application.Maintainer.MobileSuits.Queries.GetMobileSuits;
public record GetMobileSuitsQuery : IRequest<IList<MobileSuitDto>>;

public class GetMobileSuitsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetMobileSuitsQuery, IList<MobileSuitDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<MobileSuitDto>> Handle(GetMobileSuitsQuery request, CancellationToken cancellationToken)
    {
        return await _context.MobileSuits
            .Include(x => x.Manufacturer)
            .Include(x => x.Serie)
            .Include(x => x.MobileSuitPilots)
            .ThenInclude(x => x.Character)
            .ThenInclude(x => x.CharacterAffiliations)
            .ProjectTo<MobileSuitDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
