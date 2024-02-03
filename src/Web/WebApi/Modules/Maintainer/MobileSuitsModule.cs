using Application.Maintainer.MobileSuits.Commands.CreateMobileSuit;
using Application.Maintainer.MobileSuits.Commands.ToggleMobileSuit;
using Application.Maintainer.MobileSuits.Commands.UpdateMobileSuit;
using Application.Maintainer.MobileSuits.Queries.GetMobileSuitById;
using Application.Maintainer.MobileSuits.Queries.GetMobileSuits;

namespace WebApi.Modules.Maintainer;

public class MobileSuitsModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var mobileSuits = app.MapGroup("/mobile-suits");

        mobileSuits.MapGet("", GetMobileSuits);
        mobileSuits.MapGet("/{id}", GetMobileSuitById);
        mobileSuits.MapPost("", CreateMobileSuit);
        mobileSuits.MapPut("/{id}", UpdateMobileSuit);
        mobileSuits.MapDelete("/{id}", ToggleMobileSuit);
    }

    private async Task<IResult> GetMobileSuits(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetMobileSuitsQuery()));
    }

    private async Task<IResult> GetMobileSuitById(ISender sender, int id)
    {
        return Results.Ok(await sender.Send(new GetMobileSuitByIdQuery(id)));
    }

    private async Task<IResult> CreateMobileSuit(ISender sender, CreateMobileSuitCommand command)
    {
        return Results.Ok(await sender.Send(command));
    }

    private async Task<IResult> UpdateMobileSuit(ISender sender, int id, UpdateMobileSuitCommand command)
    {
        if (id != command.MobileSuitId)
            return Results.BadRequest();

        await sender.Send(command);

        return Results.NoContent();
    }

    private async Task<IResult> ToggleMobileSuit(ISender sender, int id)
    {
        await sender.Send(new ToggleMobileSuitCommand(id));

        return Results.NoContent();
    }
}
