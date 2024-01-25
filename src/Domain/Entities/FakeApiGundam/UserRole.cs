namespace Domain.Entities.FakeApiGundam;
public class UserRole : AuditableEntity
{
    private UserRole(int userId, int roleId) 
    {
        UserId = userId;
        RoleId = roleId;
    }

    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public static UserRole Create(int userId, int roleId)
    {
        return new UserRole(userId, roleId);
    }
}
