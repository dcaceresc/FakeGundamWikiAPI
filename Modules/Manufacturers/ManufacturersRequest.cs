namespace FakeGundamWikiAPI.Modules.Manufacturers;

public class CreateManufacturersRequest
{
    public string ManufacturerName { get; set; } = null!;
}

public class UpdateManufacturersRequest
{
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; } = null!;
}
