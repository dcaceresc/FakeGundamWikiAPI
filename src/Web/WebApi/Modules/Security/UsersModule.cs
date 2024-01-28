using Application.Administration.Security.Users.Commands.CreateUser;
using Application.Administration.Security.Users.Commands.ToggleUser;
using Application.Administration.Security.Users.Commands.UpdateUser;
using Application.Administration.Security.Users.Queries.GetUserById;
using Application.Administration.Security.Users.Queries.GetUsers;
namespace WebApi.Modules.Security;

public class UsersModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var users = app.MapGroup("/api/users");

        users.MapGet("", GetUsers);
        users.MapGet("/{id}", GetUsersById);
        users.MapPost("/create", CreateUser);
        users.MapPut("/update/{id}", UpdateUser);
        users.MapDelete("/toggle/{id}", ToggleUser);
    }

    private async Task<IResult> GetUsers(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetUsersQuery()));
    }

    private async Task<IResult> GetUsersById(int id, ISender sender)
    {
        return Results.Ok(await sender.Send(new GetUserByIdQuery(id)));
    }

    private async Task<IResult> CreateUser(CreateUserCommand command, ISender sender)
    {
        return Results.Ok(await sender.Send(command));
    }

    private async Task<IResult> UpdateUser(int id, UpdateUserCommand command, ISender sender)
    {
        if (id != command.UserId)
            return Results.BadRequest();

        await sender.Send(command);

        return Results.NoContent();
    }

    private async Task<IResult> ToggleUser(int id, ISender sender)
    {
        await sender.Send(new ToggleUserCommand(id));

        return Results.NoContent();
    }

}
