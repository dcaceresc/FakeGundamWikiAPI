namespace Domain.Entities;
public class Manufacturer : AuditableEntity
{
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; } = null!;
    public bool IsActive { get; set; }

    public ICollection<MobileSuit> MobileSuits { get; set; } = null!;
}
