namespace Application.Maintainer.MobileSuits.Queries.GetMobileSuitById;
public record GetMobileSuitByIdQuery(int MobileSuitId) : IRequest<MobileSuitVM>;

public class GetMobileSuitByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetMobileSuitByIdQuery, MobileSuitVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<MobileSuitVM> Handle(GetMobileSuitByIdQuery request, CancellationToken cancellationToken)
    {
        var mobileSuit = await _context.MobileSuits
            .Include(x => x.MobileSuitPilots)
            .ThenInclude(x => x.Character)
            .ProjectTo<MobileSuitVM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.MobileSuitId == request.MobileSuitId, cancellationToken);

        Guard.Against.NotFound(request.MobileSuitId, mobileSuit);

        return mobileSuit;
    }
}
