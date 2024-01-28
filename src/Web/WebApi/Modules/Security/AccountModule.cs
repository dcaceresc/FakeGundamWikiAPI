

using Application.Administration.Security.Account.Commands.AdminLogin;
using Application.Administration.Security.Account.Commands.CreateTokens;
using Application.Administration.Security.Account.Commands.UpdateRefreshToken;
using Application.Administration.Security.Account.Commands.UserLogin;

namespace WebApi.Modules.Security;

public class AccountModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var account = app.MapGroup("/api/account");

        account.MapPost("/login", UserLogin);
        account.MapPost("/admin", AdminLogin);
        account.MapPost("/refreshToken", RefreshToken);
    }

    private async Task<IResult> RefreshToken(UpdateRefreshTokenCommand command, ISender sender)
    {
        return Results.Ok(await sender.Send(command));
    }

    private async Task<IResult> AdminLogin(AdminLoginCommand command, ISender sender)
    {
        var validateAdmin = await sender.Send(command);

        if (!validateAdmin)
            return Results.Unauthorized();

        return Results.Ok(await sender.Send(new CreateTokensCommand(command.Supplanted)));
    }

    private async Task<IResult> UserLogin(UserLoginCommand command, ISender sender)
    {
        var validateUser = await sender.Send(command);

        if (!validateUser)
            return Results.Unauthorized();


        return Results.Ok(await sender.Send(new CreateTokensCommand(command.UserName)));
    }

}
