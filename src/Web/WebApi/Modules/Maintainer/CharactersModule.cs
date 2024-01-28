using Application.Administration.Maintainer.Characters.Commands.CreateCharacter;
using Application.Administration.Maintainer.Characters.Commands.ToggleCharacter;
using Application.Administration.Maintainer.Characters.Commands.UpdateCharacter;
using Application.Administration.Maintainer.Characters.Queries.GetCharacterById;
using Application.Administration.Maintainer.Characters.Queries.GetCharacters;

namespace WebApi.Modules.Maintainer;

public class CharactersModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var characters = app.MapGroup("api/characters");

        characters.MapGet("", GetCharacters);
        characters.MapGet("/{id}", GetCharacterById);
        characters.MapPost("/create", CreateCharacter);
        characters.MapPut("/update/{id}", UpdateCharacter);
        characters.MapDelete("/toggle/{id}", ToggleCharacter);
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
