using Application.Administration.Security.Users.Commands.CreateUser;
using Application.Administration.Security.Users.Commands.UpdateUser;
using Application.Administration.Security.Users.Queries.GetUserById;
using Application.Administration.Security.Users.Queries.GetUsers;
using Application.Administration.Security.Users.Commands.ToggleUser;

namespace WebApi.Controllers.Security;

[Route("api/Security/[controller]")]
[ApiController]
[Authorize(Roles = "SuperAdmin,Administrador")]
public class UsersController : ApiControllerBase
{
    [HttpGet("GetUsers")]
    public async Task<IList<UserDto>> GetUsers()
    {
        var users = await Mediator.Send(new GetUsersQuery());

        if (User.IsInRole("Administrador"))
        {
            var filteredUsers = users.Where(x => !x.RoleNames.Contains("SuperAdmin")).ToList();
            return filteredUsers;
        }
        else
        {
            return users;
        }
    }

    [HttpGet("GetUserById/{id}")]
    public async Task<UserVM> GetUserById(int id)
    {
        return await Mediator.Send(new GetUserByIdQuery(id));
    }

    [HttpPost("CreateUser")]
    public async Task<int> CreateUser([FromBody] CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("UpdateUser/{id}")]
    public async Task<IResult> UpdateUser(int id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.UserId)
            return Results.BadRequest();

        await Mediator.Send(command);

        return Results.NoContent();
    }

    [HttpDelete("ToggleUser/{id}")]
    public async Task<IResult> ToggleUser(int id)
    {
        await Mediator.Send(new ToggleUserCommand(id));

        return Results.NoContent();
    }
}
