namespace FakeGundamWikiAPI.Data.Entities;

public class MobileSuit : AuditableEntity
{
    private MobileSuit(string mobileSuitName, string mobileSuitUnitType, string mobileSuitFirstSeen, string mobileSuitLastSeen, int manufacturerId, int serieId)
    {
        MobileSuitName = mobileSuitName;
        MobileSuitUnitType = mobileSuitUnitType;
        MobileSuitFirstSeen = mobileSuitFirstSeen;
        MobileSuitLastSeen = mobileSuitLastSeen;
        ManufacturerId = manufacturerId;
        SerieId = serieId;
        IsActive = true;
    }

    public int MobileSuitId { get; set; }
    public string MobileSuitName { get; private set; } = null!;
    public string MobileSuitUnitType { get; private set; } = null!;
    public string MobileSuitFirstSeen { get; private set; } = null!;
    public string MobileSuitLastSeen { get; private set; } = null!;
    public int ManufacturerId { get; private set; }
    public Manufacturer Manufacturer { get; set; } = null!;
    public int SerieId { get; private set; }
    public Serie Serie { get; set; } = null!;

    public bool IsActive { get; private set; }

    public ICollection<MobileSuitPilot> MobileSuitPilots { get; set; } = null!;

    public static MobileSuit Create(string mobileSuitName, string mobileSuitUnitType, string mobileSuitFirstSeen, string mobileSuitLastSeen, int manufacturerId, int serieId)
    {
        return new MobileSuit(mobileSuitName, mobileSuitUnitType, mobileSuitFirstSeen, mobileSuitLastSeen, manufacturerId, serieId);
    }

    public void Update(string mobileSuitName, string mobileSuitUnitType, string mobileSuitFirstSeen, string mobileSuitLastSeen, int manufacturerId, int serieId)
    {
        MobileSuitName = mobileSuitName;
        MobileSuitUnitType = mobileSuitUnitType;
        MobileSuitFirstSeen = mobileSuitFirstSeen;
        MobileSuitLastSeen = mobileSuitLastSeen;
        ManufacturerId = manufacturerId;
        SerieId = serieId;
    }

    public MobileSuitPilot AssignPilot(int characterId)
    {
        var mobileSuitPilot = MobileSuitPilot.Create(MobileSuitId, characterId);

        return mobileSuitPilot;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }
}