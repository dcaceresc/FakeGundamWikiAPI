namespace Application.Administration.Maintainer.Affiliations.Queries.GetAffiliations;
public record GetAffiliationsQuery : IRequest<IList<AffiliationDto>>;

public class GetAffiliationsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetAffiliationsQuery, IList<AffiliationDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<AffiliationDto>> Handle(GetAffiliationsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Affiliations
            .ProjectTo<AffiliationDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
