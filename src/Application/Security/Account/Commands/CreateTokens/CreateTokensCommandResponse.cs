namespace Application.Security.Account.Commands.CreateTokens;
public class CreateTokensCommandResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}
