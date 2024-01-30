namespace Application.Maintainer.MobileSuits.Commands.UpdateMobileSuit;
public record UpdateMobileSuitCommand : IRequest
{
    public int MobileSuitId { get; init; }
    public string MobileSuitName { get; init; } = null!;
    public string MobileSuitUnitType { get; init; } = null!;
    public string MobileSuitFirstSeen { get; init; } = null!;
    public string MobileSuitLastSeen { get; init; } = null!;
    public int ManufacturerId { get; init; }
    public IList<int> PilotIds { get; init; } = null!;

}

public class UpdateMobileSuitCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateMobileSuitCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateMobileSuitCommand request, CancellationToken cancellationToken)
    {
        var mobileSuit = await _context.MobileSuits.FindAsync(new object[] { request.MobileSuitId }, cancellationToken);

        Guard.Against.NotFound(request.MobileSuitId, mobileSuit);

        mobileSuit.Update(request.MobileSuitName, mobileSuit.MobileSuitUnitType, request.MobileSuitFirstSeen, request.MobileSuitLastSeen, request.ManufacturerId);

        var oldMobileSuitPilots = await _context.MobileSuitPilots.Where(x => x.MobileSuitId == request.MobileSuitId).ToListAsync(cancellationToken);

        foreach (var item in request.PilotIds)
        {
            var existingMobileSuitPilot = oldMobileSuitPilots.FirstOrDefault(x => x.CharacterId == item);

            if (existingMobileSuitPilot == null)
            {
                var mobileSuitPilot = mobileSuit.AssignPilot(item);

                _context.MobileSuitPilots.Add(mobileSuitPilot);
            }
            else
            {
                existingMobileSuitPilot.LastModified = DateTime.Now;
            }
        }

        foreach (var item in oldMobileSuitPilots)
        {
            if (!request.PilotIds.Contains(item.MobileSuitId))
            {
                _context.MobileSuitPilots.Remove(item);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
