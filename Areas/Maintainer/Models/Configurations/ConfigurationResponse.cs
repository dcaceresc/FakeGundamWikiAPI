namespace FakeGundamWikiAPI.Areas.Maintainer.Models.Configurations;

public class ConfigurationDto
{
    public int ConfigurationId { get; set; }
    public string ConfigurationName { get; set; } = null!;
    public string ConfigurationValue { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Configuration, ConfigurationDto>();
        }
    }
}

public class ConfigurationVM
{
    public int ConfigurationId { get; set; }
    public string ConfigurationName { get; set; } = null!;
    public string ConfigurationValue { get; set; } = null!;

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Configuration, ConfigurationVM>();
        }
    }
}