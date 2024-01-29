namespace Application.Administration.Maintainer.MobileSuits.Commands.CreateMobileSuit;
public record CreateMobileSuitCommand : IRequest<int>
{
    public string MobileSuitName { get; init; } = null!;
    public string MobileSuitUnitType { get; init; } = null!;
    public string MobileSuitFirstSeen { get; init; } = null!;
    public string MobileSuitLastSeen { get; init; } = null!;
    public int ManufacturerId { get; init; }
    public IList<int> PilotIds { get; init; } = null!;
}

public class CreateMobileSuitCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateMobileSuitCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateMobileSuitCommand request, CancellationToken cancellationToken)
    {
        var entity = MobileSuit.Create(request.MobileSuitName, request.MobileSuitUnitType, request.MobileSuitFirstSeen,request.MobileSuitLastSeen, request.ManufacturerId);

        _context.MobileSuits.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.MobileSuitId;
    }
}