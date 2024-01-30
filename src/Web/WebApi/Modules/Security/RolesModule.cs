using Application.Security.Roles.Commands.CreateRole;
using Application.Security.Roles.Commands.ToggleRole;
using Application.Security.Roles.Commands.UpdateRole;
using Application.Security.Roles.Queries.GetRoleById;
using Application.Security.Roles.Queries.GetRoles;

namespace WebApi.Modules.Security;

public class RolesModule : CarterModule
{
    public RolesModule() : base("/api/roles")
    {
        RequireAuthorization("SuperAdmin");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetRoles);
        app.MapGet("/{id}", GetRolesById);
        app.MapPost("/create", CreateRole);
        app.MapPut("/update/{id}", UpdateRole);
        app.MapDelete("/toggle/{id}", ToggleRole);
    }

    private async Task<IResult> GetRoles(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetRolesQuery()));
    }

    private async Task<IResult> GetRolesById(int id, ISender sender)
    {
        return Results.Ok(await sender.Send(new GetRoleByIdQuery(id)));
    }

    private async Task<IResult> CreateRole(CreateRoleCommand command, ISender sender)
    {
        return Results.Ok(await sender.Send(command));
    }

    private async Task<IResult> UpdateRole(int id, UpdateRoleCommand command, ISender sender)
    {
        if (id != command.RoleId)
            return Results.BadRequest();

        await sender.Send(command);

        return Results.NoContent();
    }

    private async Task<IResult> ToggleRole(int id, ISender sender)
    {
        await sender.Send(new ToggleRoleCommand(id));

        return Results.NoContent();
    }
}
