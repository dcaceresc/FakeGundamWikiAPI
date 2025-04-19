﻿namespace FakeGundamWikiAPI.Data.Entities;

public class Configuration : AuditableEntity
{
    private Configuration(string configurationName, string configurationValue)
    {
        ConfigurationName = configurationName;
        ConfigurationValue = configurationValue;
        IsActive = true;
    }


    public int ConfigurationId { get; private set; }
    public string ConfigurationName { get; private set; } = null!;
    public string ConfigurationValue { get; private set; } = null!;
    public bool IsActive { get; private set; }

    public static Configuration Create(string configurationName, string configurationValue)
    {
        return new Configuration(configurationName, configurationValue);
    }

    public void Update(string configurationName, string configurationValue)
    {
        ConfigurationName = configurationName;
        ConfigurationValue = configurationValue;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }
}
