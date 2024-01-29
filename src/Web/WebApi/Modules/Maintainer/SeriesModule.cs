﻿using Application.Administration.Maintainer.Series.Commands.CreateSerie;
using Application.Administration.Maintainer.Series.Commands.ToggleSerie;
using Application.Administration.Maintainer.Series.Commands.UpdateSerie;
using Application.Administration.Maintainer.Series.Queries.GetSerieById;
using Application.Administration.Maintainer.Series.Queries.GetSeries;

namespace WebApi.Modules.Maintainer;

public class SeriesModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var series = app.MapGroup("/api/series");

        series.MapGet("", GetSeries);
        series.MapGet("/{id}", GetSeriesById);
        series.MapPost("/create", CreateSeries);
        series.MapPut("/update/{id}", UpdateSeries);
        series.MapDelete("/toggle/{id}", ToggleSeries);
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
