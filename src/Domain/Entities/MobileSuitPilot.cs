namespace Domain.Entities;
public class MobileSuitPilot : AuditableEntity
{
    public int MobileSuitId { get; set; }
    public MobileSuit MobileSuit { get; set; } = null!;
    public int CharacterId { get; set; }
    public Character Character { get; set; } = null!;
}
