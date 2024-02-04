using Application.Maintainer.Series.Commands.CreateSerie;
using Application.Maintainer.Series.Commands.ToggleSerie;
using Application.Maintainer.Series.Commands.UpdateSerie;
using Application.Maintainer.Series.Queries.GetSerieById;
using Application.Maintainer.Series.Queries.GetSeries;

namespace WebApi.Modules.Maintainer;

public class SeriesModule : CarterModule
{
    public SeriesModule() : base("api/series")
    {
        
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetSeries);
        app.MapGet("/{id}", GetSeriesById);
        app.MapPost("", CreateSeries);
        app.MapPut("/{id}", UpdateSeries);
        app.MapDelete("/{id}", ToggleSeries);
    }


    private async Task<IResult> GetSeries(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetSeriesQuery()));
    }

    private async Task<IResult> GetSeriesById(int id, ISender sender)
    {
        return Results.Ok(await sender.Send(new GetSerieByIdQuery(id)));
    }

    private async Task<IResult> CreateSeries(CreateSerieCommand command, ISender sender)
    {
        await sender.Send(command);

        return Results.Ok();
    }

    private async Task<IResult> UpdateSeries(int id, UpdateSerieCommand command, ISender sender)
    {
        if (id != command.SerieId)
            return Results.BadRequest();

        await sender.Send(command);

        return Results.Ok();
    }

    private async Task<IResult> ToggleSeries(int id, ISender sender)
    {
        await sender.Send(new ToggleSerieCommand(id));

        return Results.Ok();
    }
}
