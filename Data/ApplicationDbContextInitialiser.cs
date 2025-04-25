namespace FakeGundamWikiAPI.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}


public class ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger = logger;
    private readonly ApplicationDbContext _context = context;



    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Se produjo un error al realizar la migración de la base de datos.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Se produjo un error al inicializar la base de datos.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        await SeedRoleAsync("Administrator");

        await SeedUserAsync("admin", "User", "Administrator", "Administrator", "admin123");

        await SeedConfiguration("SiteStatus", "true");
        await SeedConfiguration("SiteURL", "https://fakegundamwikiapi.onrender.com/");


        await _context.SaveChangesAsync();
    }

    private async Task SeedRoleAsync(string roleName)
    {
        if (!_context.Roles.Any(x => x.RoleName == roleName))
        {
            var role = Role.Create(roleName);
            await _context.Roles.AddAsync(role);
        }
    }

    private async Task SeedUserAsync(string userName, string firstName, string lastName, string password, string roleName)
    {
        if (!_context.Users.Any(x => x.UserName == userName))
        {
            var user = User.Create(userName, firstName, lastName, password);

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            var role = await _context.Roles.SingleOrDefaultAsync(r => r.RoleName == roleName);

            if (role != null)
            {
                var userRole = user.AssignRole(role.RoleId);
                if (!_context.UserRoles.Any(x => x.UserId == user.UserId && x.RoleId == role.RoleId))
                {
                    await _context.UserRoles.AddAsync(userRole);
                }
            }
        }
    }

    private async Task SeedConfiguration(string configurationName, string configurationValue)
    {
        if (!_context.Configurations.Any(x => x.ConfigurationName == configurationName))
        {
            var configuration = Data.Entities.Configuration.Create(configurationName, configurationValue);
            await _context.Configurations.AddAsync(configuration);
        }
    }

}