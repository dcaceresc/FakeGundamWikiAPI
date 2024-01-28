namespace Domain.Entities;
public class Character : AuditableEntity
{
    private Character(string aliases, string characterName, string classification, string birthDate, int genderId)
    {
        Aliases = aliases;
        CharacterName = characterName;
        Classification = classification;
        BirthDate = birthDate;
        GenderId = genderId;
        IsActive = true;
    }

    public int CharacterId { get; set; }
    public string Aliases { get; set; } = null!;
    public string CharacterName { get; set; } = null!;
    public string Classification { get; set; } = null!;
    public string BirthDate { get; set; } = null!;
    public int GenderId { get; set; }
    public bool IsActive { get; set; }

    public ICollection<MobileSuitPilot> MobileSuitPilots { get; set; } = null!;
    public ICollection<CharacterAffiliation> CharacterAffiliations { get; set; } = null!;


    public static Character Create(string aliases, string characterName, string classification, string birthDate, int genderId)
    {
        return new Character(aliases, characterName, classification, birthDate, genderId);
    }

    public void Update(string aliases, string characterName, string classification, string birthDate, int genderId)
    {
        Aliases = aliases;
        CharacterName = characterName;
        Classification = classification;
        BirthDate = birthDate;
        GenderId = genderId;
    }

    public CharacterAffiliation AssignAffiliation(int affiliationId)
    {
        var characterAffiliation = CharacterAffiliation.Create(CharacterId, affiliationId);

        return characterAffiliation;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }

}
