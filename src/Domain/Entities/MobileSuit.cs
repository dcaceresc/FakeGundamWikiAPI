namespace Domain.Entities;
public class MobileSuit : AuditableEntity
{
    private MobileSuit(string mobileSuitName, string mobileSuitUnitType, string mobileSuitFirstSeen, string mobileSuitLastSeen, int manufacturerId)
    {
        MobileSuitName = mobileSuitName;
        MobileSuitUnitType = mobileSuitUnitType;
        MobileSuitFirstSeen = mobileSuitFirstSeen;
        MobileSuitLastSeen = mobileSuitLastSeen;
        ManufacturerId = manufacturerId;
    }

    public int MobileSuitId { get; set; }
    public string MobileSuitName { get; private set; } = null!;
    public string MobileSuitUnitType { get; private set; } = null!;
    public string MobileSuitFirstSeen { get; private set; } = null!;
    public string MobileSuitLastSeen { get; private set; } = null!;
    public int ManufacturerId { get; private set; }
    public Manufacturer Manufacturer { get; set; } = null!;

    public ICollection<MobileSuitPilot> MobileSuitPilots { get; set; } = null!;

    public static MobileSuit Create(string mobileSuitName, string mobileSuitUnitType, string mobileSuitFirstSeen, string mobileSuitLastSeen, int manufacturerId)
    {
        return new MobileSuit(mobileSuitName, mobileSuitUnitType, mobileSuitFirstSeen, mobileSuitLastSeen, manufacturerId);
    }
}
