using Application.Maintainer.Characters.Commands.CreateCharacter;
using Application.Maintainer.Characters.Commands.ToggleCharacter;
using Application.Maintainer.Characters.Commands.UpdateCharacter;
using Application.Maintainer.Characters.Queries.GetCharacterById;
using Application.Maintainer.Characters.Queries.GetCharacters;

namespace WebApi.Modules.Maintainer;

public class CharactersModule : CarterModule
{
    public CharactersModule() : base("api/characters")
    {

    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetCharacters);
        app.MapGet("/{id}", GetCharacterById);
        app.MapPost("", CreateCharacter);
        app.MapPut("/{id}", UpdateCharacter);
        app.MapDelete("/{id}", ToggleCharacter);
    }

    private async Task<IResult> GetCharacters(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetCharactersQuery()));
    }

    private async Task<IResult> GetCharacterById(int id, ISender sender)
    {
        return Results.Ok(await sender.Send(new GetCharacterByIdQuery(id)));
    }

    private async Task<IResult> CreateCharacter(CreateCharacterCommand command, ISender sender)
    {
        return Results.Ok(await sender.Send(command));
    }

    private async Task<IResult> UpdateCharacter(int id, UpdateCharacterCommand command, ISender sender)
    {
        if (id != command.CharacterId)
            return Results.BadRequest();

        await sender.Send(command);

        return Results.NoContent();
    }

    private async Task<IResult> ToggleCharacter(int id, ISender sender)
    {
        await sender.Send(new ToggleCharacterCommand(id));

        return Results.NoContent();
    }
}
