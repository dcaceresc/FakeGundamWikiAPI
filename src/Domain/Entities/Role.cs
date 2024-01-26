namespace Domain.Entities;
public class Role : AuditableEntity
{
    private Role(string roleName)
    {
        RoleName = roleName;
        IsActive = true;
    }

    public int RoleId { get; private set; }
    public string RoleName { get; private set; } = null!;
    public bool IsActive { get; private set; }

    public ICollection<UserRole> UserRoles { get; set; } = null!;

    public static Role Create(string roleName)
    {
        return new Role(roleName);
    }

    public void Update(string roleName)
    {
        RoleName = roleName;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }
}
