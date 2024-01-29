namespace Domain.Entities;
public class MobileSuitPilot : AuditableEntity
{
    private MobileSuitPilot(int mobileSuitId, int characterId)
    {
        MobileSuitId = mobileSuitId;
        CharacterId = characterId;
    }

    public int MobileSuitId { get; private set; }
    public MobileSuit MobileSuit { get; set; } = null!;
    public int CharacterId { get; private set; }
    public Character Character { get; set; } = null!;

    public static MobileSuitPilot Create(int mobileSuitId, int characterId)
    {
        return new MobileSuitPilot(mobileSuitId, characterId);
    }
}
