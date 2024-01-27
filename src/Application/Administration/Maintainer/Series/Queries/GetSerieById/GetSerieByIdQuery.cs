namespace Application.Administration.Maintainer.Series.Queries.GetSerieById;
public record GetSerieByIdQuery(int SerieId) : IRequest<SerieVM>;

public class GetSerieByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetSerieByIdQuery, SerieVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<SerieVM> Handle(GetSerieByIdQuery request, CancellationToken cancellationToken)
    {
        var serie = await _context.Series
            .ProjectTo<SerieVM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(s => s.SerieId == request.SerieId, cancellationToken);

        Guard.Against.NotFound(request.SerieId, serie);

        return serie;
    }
}

