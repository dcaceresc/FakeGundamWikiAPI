namespace Domain.Entities;
public class Affiliation : AuditableEntity
{
    private Affiliation(string affiliationName, string affiliationPurpose)
    {
        AffiliationName = affiliationName;
        AffiliationPurpose = affiliationPurpose;
        IsActive = true;
    }
    public int AffiliationId { get; set; }
    public string AffiliationName { get; set; } = null!;
    public string AffiliationPurpose { get; set; } = null!;
    public bool IsActive { get; set; }

    public ICollection<CharacterAffiliation> CharacterAffiliations { get; set; } = null!;

    public static Affiliation Create(string affiliationName, string affiliationPurpose)
    {
        return new Affiliation(affiliationName, affiliationPurpose);
    }

    public void Update(string affiliationName, string affiliationPurpose)
    {
        AffiliationName = affiliationName;
        AffiliationPurpose = affiliationPurpose;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }
}
