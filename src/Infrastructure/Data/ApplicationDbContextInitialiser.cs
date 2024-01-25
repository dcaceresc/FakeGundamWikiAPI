using Domain.Constants;
using Domain.Entities.FakeApiGundam;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

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
        await SeedRoleAsync(Roles.SuperAdmin);
        await SeedRoleAsync(Roles.Administrator);

        await SeedUserAsync("dcaceresc", "Diego", "Cáceres", "SuperAdmin");

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

    private async Task SeedUserAsync(string userName, string firstName, string lastName, string roleName)
    {
        if (!_context.Users.Any(x => x.UserName == userName))
        {
            var user = User.Create(userName, firstName, lastName);

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
}
