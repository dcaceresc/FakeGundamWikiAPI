namespace FakeGundamWikiAPI.Modules.Roles;

public class CreateRoleRequest
{
    public string RoleName { get; set; } = null!;
}

public class UpdateRoleRequest
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
}