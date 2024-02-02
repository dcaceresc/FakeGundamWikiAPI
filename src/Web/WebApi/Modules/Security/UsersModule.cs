using Application.Security.Users.Commands.CreateUser;
using Application.Security.Users.Commands.ToggleUser;
using Application.Security.Users.Commands.UpdateUser;
using Application.Security.Users.Queries.GetUserById;
using Application.Security.Users.Queries.GetUsers;

namespace WebApi.Modules.Security;

public class UsersModule : CarterModule
{
    public UsersModule()
        : base("/api/users")
    {
        RequireAuthorization("Administrator");
    }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetUsers);
        app.MapGet("/{id}", GetUsersById);
        app.MapPost("", CreateUser);
        app.MapPut("/{id}", UpdateUser);
        app.MapDelete("/{id}", ToggleUser);
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
