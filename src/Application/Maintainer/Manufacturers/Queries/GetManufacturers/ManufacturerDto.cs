namespace Application.Maintainer.Manufacturers.Queries.GetManufacturers;

public class ManufacturerDto
{
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Manufacturer, ManufacturerDto>();
        }
    }
}