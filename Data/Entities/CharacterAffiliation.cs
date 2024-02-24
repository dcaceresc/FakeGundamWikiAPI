namespace FakeGundamWikiAPI.Data.Entities;

public class CharacterAffiliation : AuditableEntity
{
    private CharacterAffiliation(int characterId, int affiliationId)
    {
        CharacterId = characterId;
        AffiliationId = affiliationId;
    }
    public int CharacterId { get; private set; }
    public Character Character { get; set; } = null!;
    public int AffiliationId { get; private set; }
    public Affiliation Affiliation { get; set; } = null!;

    public static CharacterAffiliation Create(int characterId, int affiliationId)
    {
        return new CharacterAffiliation(characterId, affiliationId);
    }
}
