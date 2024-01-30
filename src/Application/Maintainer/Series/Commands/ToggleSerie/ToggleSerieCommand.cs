namespace Application.Maintainer.Series.Commands.ToggleSerie;
public record ToggleSerieCommand(int SerieId) : IRequest;

public class ToggleSerieCommandHandler(IApplicationDbContext context) : IRequestHandler<ToggleSerieCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(ToggleSerieCommand request, CancellationToken cancellationToken)
    {
        var serie = await _context.Series.FindAsync(new object[] { request.SerieId }, cancellationToken);

        Guard.Against.NotFound(request.SerieId, serie);

        serie.ToggleActive();

        await _context.SaveChangesAsync(cancellationToken);

    }
}
