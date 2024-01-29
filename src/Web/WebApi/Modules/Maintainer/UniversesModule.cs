using Application.Administration.Maintainer.Universes.Commands.CreateUniverse;
using Application.Administration.Maintainer.Universes.Commands.ToggleUniverse;
using Application.Administration.Maintainer.Universes.Commands.UpdateUniverse;
using Application.Administration.Maintainer.Universes.Queries.GetUniverseById;
using Application.Administration.Maintainer.Universes.Queries.GetUniverses;

namespace WebApi.Modules.Maintainer;

public class UniversesModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var universes = app.MapGroup("/api/universes");

        universes.MapGet("", GetUniverses);
        universes.MapGet("/{id}", GetUniversesById);
        universes.MapPost("/create", CreateUniverse);
        universes.MapPut("/update/{id}", UpdateUniverse);
        universes.MapDelete("/toggle/{id}", ToggleUniverse);
    }

    private async Task<IResult> GetUniverses(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetUniversesQuery()));
    }

    private async Task<IResult> GetUniversesById(int id, ISender sender)
    {
        return Results.Ok(await sender.Send(new GetUniverseByIdQuery(id)));
    }

    private async Task<IResult> CreateUniverse(CreateUniverseCommand command, ISender sender)
    {
        await sender.Send(command);

        return Results.Ok();
    }

    private async Task<IResult> UpdateUniverse(int id, UpdateUniverseCommand command, ISender sender)
    {
        if (id != command.UniverseId)
            return Results.BadRequest();

        await sender.Send(command);

        return Results.Ok();
    }

    private async Task<IResult> ToggleUniverse(int id, ISender sender)
    {
        await sender.Send(new ToggleUniverseCommand(id));

        return Results.Ok();
    }
}
