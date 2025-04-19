namespace FakeGundamWikiAPI.Data.Entities;

public class User : AuditableEntity
{
    private User(string userName, string firstName, string lastName, string hashPassword)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        HashPassword = hashPassword;
        IsActive = true;
    }

    public int UserId { get; private set; }
    public string UserName { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string HashPassword { get; private set; } = null!;
    public bool IsActive { get; private set; }

    public ICollection<UserRole> UserRoles { get; set; } = null!;
    public ICollection<RefreshToken> RefreshTokens { get; set; } = null!;

    public static User Create(string userName, string firstName, string lastName, string hashPassword)
    {
        return new User(userName, firstName, lastName, hashPassword);
    }

    public void Update(string userName, string firstName, string lastName, string hashPassword)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        HashPassword = hashPassword;
    }

    public UserRole AssignRole(int roleId)
    {
        var userRole = UserRole.Create(UserId, roleId);

        return userRole;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }
}
