namespace Domain.Entities;
public class Affiliation : AuditableEntity
{
    public int AffiliationId { get; set; }
    public string AffiliationName { get; set; } = null!;
    public string AffiliationPurpose { get; set; } = null!;
    public bool IsActive { get; set; }

    public ICollection<CharacterAffiliation> CharacterAffiliations { get; set; } = null!;
}
