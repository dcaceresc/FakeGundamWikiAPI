namespace FakeGundamWikiAPI.Data.Configuration;

public static class InitialiserExtensions
{
    public static async Task InitialiseConfigurationAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ConfigurationInitializer>();

        await initialiser.InitialiseAsync();
    }
}

public class ConfigurationInitializer(ILogger<ConfigurationInitializer> logger, ApplicationDbContext context)
{
    private readonly ILogger<ConfigurationInitializer> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    public async Task InitialiseAsync()
    {
        try
        {
            var configurations = await _context.Configurations
                .Where(c => c.IsActive)
                .ToListAsync();


            foreach (var configuration in configurations)
            {
                SiteConfig.SiteStatus = Convert.ToBoolean(configurations.Find(x => x.ConfigurationName.Equals("SiteStatus", StringComparison.CurrentCultureIgnoreCase))?.ConfigurationValue ?? "true");
                SiteConfig.SiteUrl = configurations.Find(x => x.ConfigurationName.Equals("SiteUrl", StringComparison.CurrentCultureIgnoreCase))?.ConfigurationValue ?? "";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the configuration.");
            throw;
        }
    }
}