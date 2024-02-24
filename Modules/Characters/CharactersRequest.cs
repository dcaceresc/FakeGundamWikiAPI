namespace FakeGundamWikiAPI.Modules.Characters;

public class CreateCharacterRequest
{
    public string CharacterName { get; set; } = null!;
    public string CharacterAliases { get; set; } = null!;
    public string CharacterClassification { get; set; } = null!;
    public string CharacterBirthDate { get; set; } = null!;
    public int CharacterGenderId { get; set; }
    public IList<int> AffiliationIds { get; set; } = null!;
}

public class UpdateCharacterRequest
{
    public int CharacterId { get; set; }
    public string CharacterName { get; set; } = null!;
    public string CharacterAliases { get; set; } = null!;
    public string CharacterClassification { get; set; } = null!;
    public string CharacterBirthDate { get; set; } = null!;
    public int CharacterGenderId { get; set; }
    public IList<int> AffiliationIds { get; set; } = null!;
}