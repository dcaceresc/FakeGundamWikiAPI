namespace Domain.Entities;
public class Character : AuditableEntity
{
    public int CharacterId { get; set; }
    public string Aliases { get; set; } = null!;
    public string CharacterName { get; set; } = null!;
    public string Classification { get; set; } = null!;
    public string BirthDate { get; set; } = null!;
    public int GenderId { get; set; }
    public bool IsActive { get; set; }

    public ICollection<MobileSuitPilot> MobileSuitPilots { get; set; } = null!;
    public ICollection<CharacterAffiliation> CharacterAffiliations { get; set; } = null!;

}
