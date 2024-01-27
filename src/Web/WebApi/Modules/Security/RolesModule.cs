using Application.Administration.Security.Roles.Commands.CreateRole;
using Application.Administration.Security.Roles.Commands.ToggleRole;
using Application.Administration.Security.Roles.Commands.UpdateRole;
using Application.Administration.Security.Roles.Queries.GetRoleById;
using Application.Administration.Security.Roles.Queries.GetRoles;

namespace WebApi.Modules.Security;

public class RolesModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/roles", GetRoles)
            .RequireAuthorization();
        app.MapGet("/roles/{id}", GetRolesById);
        app.MapPost("/roles/create", CreateRole);
        app.MapPut("/roles/update/{id}", UpdateRole);
        app.MapDelete("/roles/toggle/{id}", ToggleRole);
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
