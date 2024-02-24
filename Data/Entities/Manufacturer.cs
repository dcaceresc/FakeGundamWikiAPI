namespace FakeGundamWikiAPI.Data.Entities;

public class Manufacturer : AuditableEntity
{
    private Manufacturer(string manufacturerName)
    {
        ManufacturerName = manufacturerName;
        IsActive = true;
    }
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; private set; } = null!;
    public bool IsActive { get; private set; }

    public ICollection<MobileSuit> MobileSuits { get; set; } = null!;

    public static Manufacturer Create(string manufacturerName)
    {
        return new Manufacturer(manufacturerName);
    }

    public void Update(string manufacturerName)
    {
        ManufacturerName = manufacturerName;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }


}