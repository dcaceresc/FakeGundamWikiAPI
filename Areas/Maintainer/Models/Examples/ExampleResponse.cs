namespace FakeGundamWikiAPI.Areas.Maintainer.Models.Examples;

public class ExampleDto
{
    public int ExampleId { get; set; }
    public string ExampleName { get; set; } = null!;
    public string ExampleCode { get; set; } = null!;
    public string? ExampleResult { get; set; }
    public string ExampleTypeName { get; set; } = null!;
    public bool IsActive { get; set; }


    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Example, ExampleDto>()
                .ForMember(dest => dest.ExampleTypeName, opt => opt.MapFrom(src => src.ExampleType.ExampleTypeName)
                                                                     );
        }
    }

}


public class ExampleVM
{
    public int ExampleId { get; set; }
    public string ExampleName { get; set; } = null!;
    public string ExampleCode { get; set; } = null!;
    public string? ExampleResult { get; set; }
    public int ExampleTypeId { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Example, ExampleVM>();
        }
    }
}