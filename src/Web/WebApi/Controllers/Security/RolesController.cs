using Application.Administration.Security.Roles.Commands.CreateRole;
using Application.Administration.Security.Roles.Commands.UpdateRole;
using Application.Administration.Security.Roles.Queries.GetRoleById;
using Application.Administration.Security.Roles.Queries.GetRoles;
using Application.Administration.Security.Roles.Commands.ToggleRole;

namespace WebApi.Controllers.Security;

[Route("api/Security/[controller]")]
[ApiController]
[Authorize(Roles = "SuperAdmin,Administrador")]
public class RolesController : ApiControllerBase
{
    [HttpGet("GetRoles")]

    public async Task<IList<RoleDto>> GetRoles()
    {
        var roles = await Mediator.Send(new GetRolesQuery());

        if (User.IsInRole("Administrador"))
        {
            var filteredUsers = roles.Where(x => x.RoleName != "SuperAdmin").ToList();
            return filteredUsers;
        }
        else
        {
            return roles;
        }
    }

    [HttpGet("GetRoleById/{id}")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<RoleVM> GetRoleById(int id)
    {
        return await Mediator.Send(new GetRoleByIdQuery(id));
    }

    [HttpPost("CreateRole")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<int> CreateRole([FromBody] CreateRoleCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("UpdateRole/{id}")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IResult> UpdateRole(int id, [FromBody] UpdateRoleCommand command)
    {
        if (id != command.RoleId)
            return Results.BadRequest();

        await Mediator.Send(command);

        return Results.NoContent();
    }

    [HttpDelete("ToggleRole/{id}")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IResult> ToggleRole(int id)
    {
        await Mediator.Send(new ToggleRoleCommand(id));

        return Results.NoContent();
    }
}
