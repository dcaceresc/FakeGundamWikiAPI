namespace FakeGundamWikiAPI.Modules.Users;

public class CreateUserRequest
{
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public IList<int> RolesId { get; set; } = null!;
}

public class UpdateUserRequest
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public IList<int> RolesId { get; set; } = null!;
}