namespace Application.Administration.Maintainer.Manufacturers.Queries.GetManufacturerById;

public class ManufacturerVM
{
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; } = null!;

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Manufacturer, ManufacturerVM>();
        }
    }
}