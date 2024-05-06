namespace FakeGundamWikiAPI.Areas.Maintainer.Models.ExampleTypes;

public class ExampleTypeDto
{
    public int ExampleTypeId { get; set; }
    public string ExampleTypeName { get; set; } = null!;
    public bool IsActive { get; set; }


    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ExampleType, ExampleTypeDto>();
        }
    }
}

public class ExampleTypeVM
{
    public int ExampleTypeId { get; set; }
    public string ExampleTypeName { get; set; } = null!;

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ExampleType, ExampleTypeVM>();
        }
    }
}