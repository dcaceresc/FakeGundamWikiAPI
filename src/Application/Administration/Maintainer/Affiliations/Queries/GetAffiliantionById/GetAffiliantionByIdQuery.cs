namespace Application.Administration.Maintainer.Affiliations.Queries.GetAffiliantionById;
public record GetAffiliantionByIdQuery(int AffiliantionId) : IRequest<AffiliationVM>;

public class GetAffiliantionByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetAffiliantionByIdQuery, AffiliationVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<AffiliationVM> Handle(GetAffiliantionByIdQuery request, CancellationToken cancellationToken)
    {
        var affiliantion = await _context.Affiliations
            .ProjectTo<AffiliationVM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.AffiliationId == request.AffiliantionId, cancellationToken);

        Guard.Against.NotFound(request.AffiliantionId, affiliantion);

        return affiliantion;
    }
}
