namespace FakeGundamWikiAPI.Areas.Security.Models.Account;

public class AdminLoginRequest
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}