namespace Domain.Entities;
public class User : AuditableEntity
{
    private User(string userName, string firstName, string lastName)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        IsActive = true;
    }

    public int UserId { get; private set; }
    public string UserName { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public bool IsActive { get; private set; }

    public ICollection<UserRole> UserRoles { get; set; } = null!;
    public ICollection<RefreshToken> RefreshTokens { get; set; } = null!;

    public static User Create(string userName, string firstName, string lastName)
    {
        return new User(userName, firstName, lastName);
    }

    public void Update(string userName, string firstName, string lastName)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
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
