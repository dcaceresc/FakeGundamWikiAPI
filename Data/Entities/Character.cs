namespace FakeGundamWikiAPI.Data.Entities;

public class Character : AuditableEntity
{
    private Character(string characterName, string characterAliases, string characterClassification, string characterBirthDate, int characterGenderId)
    {
        CharacterName = characterName;
        CharacterAliases = characterAliases;
        CharacterClassification = characterClassification;
        CharacterBirthDate = characterBirthDate;
        CharacterGenderId = characterGenderId;
        IsActive = true;
    }

    public int CharacterId { get; set; }
    public string CharacterAliases { get; set; } = null!;
    public string CharacterName { get; set; } = null!;
    public string CharacterClassification { get; set; } = null!;
    public string CharacterBirthDate { get; set; } = null!;
    public int CharacterGenderId { get; set; }
    public bool IsActive { get; set; }

    public ICollection<MobileSuitPilot> MobileSuitPilots { get; set; } = null!;
    public ICollection<CharacterAffiliation> CharacterAffiliations { get; set; } = null!;


    public static Character Create(string characterName, string characterAliases, string characterClassification, string characterBirthDate, int characterGenderId)
    {
        return new Character(characterAliases, characterName, characterClassification, characterBirthDate, characterGenderId);
    }

    public void Update(string aliases, string characterName, string classification, string birthDate, int genderId)
    {
        CharacterName = characterName;
        CharacterAliases = aliases;
        CharacterClassification = classification;
        CharacterBirthDate = birthDate;
        CharacterGenderId = genderId;
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