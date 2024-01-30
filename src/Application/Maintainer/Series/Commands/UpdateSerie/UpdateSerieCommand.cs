namespace Application.Maintainer.Series.Commands.UpdateSerie;
public record UpdateSerieCommand(int SerieId, string SerieName, int UniverseId) : IRequest;

public class UpdateSerieCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateSerieCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateSerieCommand request, CancellationToken cancellationToken)
    {
        var serie = await _context.Series.FindAsync(new object[] { request.SerieId }, cancellationToken);

        Guard.Against.NotFound(request.SerieId, serie);

        serie.Update(request.SerieName, request.UniverseId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
