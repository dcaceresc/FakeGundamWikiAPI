namespace FakeGundamWikiAPI.Areas.Security.Models.Users;

public class CreateUserRequest
{
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public List<int> RoleIds { get; set; } = null!;
}

public class EditUserRequest
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public List<int> RoleIds { get; set; } = null!;
}
