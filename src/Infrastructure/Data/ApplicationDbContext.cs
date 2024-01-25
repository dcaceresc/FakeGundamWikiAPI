using Domain.Entities.FakeApiGundam;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{

    public DbSet<User> Users => Set<User>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Role> Roles => Set<Role>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId);

            entity.Property(e => e.RefreshTokenValue)
            .HasColumnType("varchar(32)");
        });

        builder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.HasIndex(e => e.RoleName)
            .IsUnique();

            entity.Property(e => e.RoleName)
            .HasColumnType("varchar(30)");
        });

        builder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.HasIndex(e => e.UserName)
            .IsUnique();

            entity.Property(e => e.UserName)
            .HasColumnType("varchar(30)");

            entity.Property(e => e.FirstName)
            .HasColumnType("varchar(30)");

            entity.Property(e => e.LastName)
            .HasColumnType("varchar(30)");
        });

        builder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });

            entity.HasOne(e => e.User)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.UserId);

            entity.HasOne(e => e.Role)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.RoleId);
        });

        ConfigureAuditableEntity<RefreshToken>(builder);
        ConfigureAuditableEntity<Role>(builder);
        ConfigureAuditableEntity<User>(builder);
        ConfigureAuditableEntity<UserRole>(builder);

        base.OnModelCreating(builder);
    }

    private static void ConfigureAuditableEntity<T>(ModelBuilder builder) where T : AuditableEntity
    {
        builder.Entity<T>()
            .Property(e => e.CreatedBy)
            .HasColumnType("varchar(30)");

        builder.Entity<T>()
            .Property(e => e.LastModifiedBy)
            .HasColumnType("varchar(30)");
    }

}
