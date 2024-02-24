namespace FakeGundamWikiAPI.Modules.MobileSuits;


public class CreateMobileSuitRequest
{
    public string MobileSuitName { get; init; } = null!;
    public string MobileSuitUnitType { get; init; } = null!;
    public string MobileSuitFirstSeen { get; init; } = null!;
    public string MobileSuitLastSeen { get; init; } = null!;
    public int ManufacturerId { get; init; }
    public int SerieId { get; init; }
    public IList<int> PilotIds { get; init; } = null!;
}

public class UpdateMobileSuitRequest
{
    public int MobileSuitId { get; init; }
    public string MobileSuitName { get; init; } = null!;
    public string MobileSuitUnitType { get; init; } = null!;
    public string MobileSuitFirstSeen { get; init; } = null!;
    public string MobileSuitLastSeen { get; init; } = null!;
    public int ManufacturerId { get; init; }
    public int SerieId { get; init; }
    public IList<int> PilotIds { get; init; } = null!;
}
