namespace Application.Maintainer.Manufacturers.Queries.GetManufacturerById;

public class ManufacturerVM : AuditableEntity
{
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Manufacturer, ManufacturerVM>();
        }
    }
}