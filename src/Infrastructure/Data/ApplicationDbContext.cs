using Domain.Entities;

namespace Infrastructure.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Affiliation> Affiliations => Set<Affiliation>();
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<CharacterAffiliation> CharacterAffiliations => Set<CharacterAffiliation>();
    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
    public DbSet<MobileSuit> MobileSuits => Set<MobileSuit>();
    public DbSet<MobileSuitPilot> MobileSuitPilots => Set<MobileSuitPilot>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Serie> Series => Set<Serie>();
    public DbSet<Universe> Universes => Set<Universe>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();




    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Affiliation>(entity =>
        {
            entity.HasKey(e => e.AffiliationId);

            entity.HasIndex(e => e.AffiliationName)
            .IsUnique();

            entity.Property(e => e.AffiliationName)
            .HasColumnType("varchar(100)");

            entity.Property(e => e.AffiliationPurpose)
            .HasColumnType("varchar(200)");
        });

        builder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.CharacterId);

            entity.HasIndex(e => e.CharacterName)
            .IsUnique();

            entity.Property(e => e.CharacterName)
            .HasColumnType("varchar(100)");

            entity.Property(e => e.Aliases)
            .HasColumnType("varchar(200)");

            entity.Property(e => e.Classification)
            .HasColumnType("varchar(100)");

            entity.Property(e => e.BirthDate)
            .HasColumnType("varchar(50)");
        });

        builder.Entity<CharacterAffiliation>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.AffiliationId });

            entity.HasOne(e => e.Character)
            .WithMany(e => e.CharacterAffiliations)
            .HasForeignKey(e => e.CharacterId);

            entity.HasOne(e => e.Affiliation)
            .WithMany(e => e.CharacterAffiliations)
            .HasForeignKey(e => e.AffiliationId);
        });

        builder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId);

            entity.HasIndex(e => e.ManufacturerName)
            .IsUnique();

            entity.Property(e => e.ManufacturerName)
            .HasColumnType("varchar(100)");
        });

        builder.Entity<MobileSuit>(entity =>
        {
            entity.HasKey(e => e.MobileSuitId);

            entity.HasIndex(e => e.MobileSuitName)
            .IsUnique();

            entity.Property(e => e.MobileSuitName)
            .HasColumnType("varchar(100)");

            entity.Property(e => e.UnitType)
            .HasColumnType("varchar(100)");

            entity.Property(e => e.FirstSeen)
            .HasColumnType("varchar(50)");

            entity.Property(e => e.LastSeen)
            .HasColumnType("varchar(50)");

        });

        builder.Entity<MobileSuitPilot>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.MobileSuitId });

            entity.HasOne(e => e.Character)
            .WithMany(e => e.MobileSuitPilots)
            .HasForeignKey(e => e.CharacterId);

            entity.HasOne(e => e.MobileSuit)
            .WithMany(e => e.MobileSuitPilots)
            .HasForeignKey(e => e.MobileSuitId);
        });


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

        builder.Entity<Serie>(entity =>
        {
            entity.HasKey(e => e.SerieId);

            entity.HasIndex(e => e.SerieName)
            .IsUnique();

            entity.Property(e => e.SerieName)
            .HasColumnType("varchar(100)");

        });

        builder.Entity<Universe>(entity =>
        {
            entity.HasKey(e => e.UniverseId);

            entity.HasIndex(e => e.UniverseName)
            .IsUnique();

            entity.Property(e => e.UniverseName)
            .HasColumnType("varchar(100)");

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

        ConfigureAuditableEntity<Affiliation>(builder);
        ConfigureAuditableEntity<Character>(builder);
        ConfigureAuditableEntity<CharacterAffiliation>(builder);
        ConfigureAuditableEntity<Manufacturer>(builder);
        ConfigureAuditableEntity<MobileSuit>(builder);
        ConfigureAuditableEntity<MobileSuitPilot>(builder);
        ConfigureAuditableEntity<Manufacturer>(builder);
        ConfigureAuditableEntity<RefreshToken>(builder);
        ConfigureAuditableEntity<Role>(builder);
        ConfigureAuditableEntity<Serie>(builder);
        ConfigureAuditableEntity<Universe>(builder);
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
