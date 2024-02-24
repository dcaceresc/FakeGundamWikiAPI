﻿namespace FakeGundamWikiAPI.Modules.Series;

public class SeriesModule() : CarterModule("api/series")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetSeries);
        app.MapGet("{id:int}", GetSeriesById);
        app.MapPost("", CreateSeries);
        app.MapPut("{id:int}", UpdateSeries);
        app.MapDelete("{id:int}", ToggleSeries);
    }


    public async Task<IResult> GetSeries(ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var series = await context.Series
            .Include(s => s.Universe)
            .ProjectTo<SerieResponse>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Results.Ok(series);
    }

    public async Task<IResult> GetSeriesById(int id, ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var serie = await context.Series
            .Include(s => s.Universe)
            .ProjectTo<SerieResponse>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(s => s.SerieId == id, cancellationToken);

        if (serie == null)
            return Results.NotFound();

        return Results.Ok(serie);
    }

    public async Task<IResult> CreateSeries([FromBody] CreateSeriesRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var serie = Serie.Create(request.SerieName, request.UniverseId);

        context.Series.Add(serie);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Created($"/api/series/{serie.SerieId}", serie);

    }

    public async Task<IResult> UpdateSeries(int id, [FromBody] UpdateSeriesRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        if (request.SerieId != id)
            return Results.BadRequest("The serie id in the request does not match the id in the route");

        var serie = await context.Series.FindAsync(new object[] { id }, cancellationToken);

        if (serie == null)
            return Results.NotFound();

        serie.Update(request.SerieName, request.UniverseId);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok(serie);
    }

    public async Task<IResult> ToggleSeries(int id, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var serie = await context.Series.FindAsync(new object[] { id }, cancellationToken);

        if (serie == null)
            return Results.NotFound();

        serie.ToggleActive();

        await context.SaveChangesAsync(cancellationToken);

        return Results.NoContent();
    }
}
