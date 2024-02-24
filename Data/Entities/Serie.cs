namespace FakeGundamWikiAPI.Data.Entities;

public class Serie : AuditableEntity
{
    private Serie(string serieName, int universeId)
    {
        SerieName = serieName;
        UniverseId = universeId;
        IsActive = true;
    }

    public int SerieId { get; set; }
    public string SerieName { get; private set; } = null!;
    public int UniverseId { get; private set; }
    public Universe Universe { get; set; } = null!;
    public bool IsActive { get; private set; }

    public static Serie Create(string serieName, int universeId)
    {
        return new Serie(serieName, universeId);
    }

    public void Update(string serieName, int universeId)
    {
        SerieName = serieName;
        UniverseId = universeId;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }
}