namespace Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Affiliation> Affiliations { get; }
    DbSet<Character> Characters { get; }
    DbSet<CharacterAffiliation> CharacterAffiliations { get; }
    DbSet<Manufacturer> Manufacturers { get; }
    DbSet<MobileSuit> MobileSuits { get; }
    DbSet<MobileSuitPilot> MobileSuitPilots { get; }
    DbSet<RefreshToken> RefreshTokens { get; }
    DbSet<Role> Roles { get; }
    DbSet<Serie> Series { get; }
    DbSet<Universe> Universes { get; }
    DbSet<User> Users { get; }
    DbSet<UserRole> UserRoles { get; }



    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
