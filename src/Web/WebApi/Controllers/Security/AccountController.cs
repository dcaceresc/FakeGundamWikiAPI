using Application.Administration.Security.Account.Commands.AdminLogin;
using Application.Administration.Security.Account.Commands.UpdateRefreshToken;
using Application.Administration.Security.Account.Commands.UserLogin;
using Application.Administration.Security.Account.Commands.CreateTokens;

namespace WebApi.Controllers.Security;
[Route("api/Security/[controller]")]
[ApiController]
public class AccountController : ApiControllerBase
{

    [HttpPost("UserLogin")]
    public async Task<IActionResult> UserLogin([FromBody] UserLoginCommand command)
    {
        var validateUser = await Mediator.Send(command);

        if (validateUser)
        {
            return Ok(await Mediator.Send(new CreateTokensCommand(command.UserName)));
        }
        else
        {
            return Unauthorized();
        }
    }


    [HttpPost("AdminLogin")]
    public async Task<IActionResult> AdminLogin([FromBody] AdminLoginCommand command)
    {
        var validateAdmin = await Mediator.Send(command);

        if (validateAdmin)
        {
            return Ok(await Mediator.Send(new CreateTokensCommand(command.Supplanted)));
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] UpdateRefreshTokenCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
