namespace Domain.Entities;
public class CharacterAffiliation : AuditableEntity
{
    public int CharacterId { get; set; }
    public Character Character { get; set; } = null!;
    public int AffiliationId { get; set; }
    public Affiliation Affiliation { get; set; } = null!;
}
