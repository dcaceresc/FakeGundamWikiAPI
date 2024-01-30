namespace Application.Security.Account.Commands.UpdateRefreshToken;

public class UpdateRefreshTokenCommandResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}