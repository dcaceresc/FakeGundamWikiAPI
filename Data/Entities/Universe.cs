namespace FakeGundamWikiAPI.Data.Entities;

public class Universe : AuditableEntity
{
    private Universe(string universeName)
    {
        UniverseName = universeName;
        IsActive = true;
    }

    public int UniverseId { get; set; }
    public string UniverseName { get; set; } = null!;
    public bool IsActive { get; set; }

    public ICollection<Serie> Series { get; set; } = null!;

    public static Universe Create(string universeName)
    {
        return new Universe(universeName);
    }

    public void Update(string universeName)
    {
        UniverseName = universeName;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }
}