namespace Application.Administration.Maintainer.Series.Commands.CreateSerie;
public record CreateSerieCommand(string SerieName, int UniverseId) : IRequest<int>;

public class CreateSerieCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateSerieCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateSerieCommand request, CancellationToken cancellationToken)
    {
        var serie = Serie.Create(request.SerieName, request.UniverseId);

        _context.Series.Add(serie);

        await _context.SaveChangesAsync(cancellationToken);

        return serie.SerieId;
    }
}

