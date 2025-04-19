namespace FakeGundamWikiAPI.Areas.Security.Models.Roles;

public class CreateRoleRequest
{
    public string RoleName { get; set; } = null!;
}

public class EditRoleRequest
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
}
