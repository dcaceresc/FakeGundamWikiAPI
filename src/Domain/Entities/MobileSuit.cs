namespace Domain.Entities;
public class MobileSuit : AuditableEntity
{
    public int MobileSuitId { get; set; }
    public string MobileSuitName { get; set; } = null!;
    public string UnitType { get; set; } = null!;
    public string FirstSeen { get; set; } = null!;
    public string LastSeen { get; set; } = null!;
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; } = null!;

    public ICollection<MobileSuitPilot> MobileSuitPilots { get; set; } = null!;
}
