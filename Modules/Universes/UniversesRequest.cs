namespace FakeGundamWikiAPI.Modules.Universes;

public class CreateUniverseRequest
{
    public string UniverseName { get; set; } = null!;
}

public class UpdateUniverseRequest
{
    public int UniverseId { get; set; }
    public string UniverseName { get; set; } = null!;
}