namespace Application.Common.Interfaces;

public interface IAuthenticationService
{
    string? UserId { get; }
    public string CreateAccessToken(string username, IList<string> roles);
}