namespace FakeGundamWikiAPI.Areas.Maintainer.Models.Configurations;

public class CreateConfigurationRequest
{
    public string ConfigurationName { get; set; } = string.Empty;
    public string ConfigurationValue { get; set; } = string.Empty;
}

public class UpdateConfigurationRequest
{
    public int ConfigurationId { get; set; }
    public string ConfigurationName { get; set; } = string.Empty;
    public string ConfigurationValue { get; set; } = string.Empty;
}