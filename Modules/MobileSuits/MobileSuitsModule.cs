namespace FakeGundamWikiAPI.Modules.MobileSuits;

public class MobileSuitsModule() : CarterModule("api/mobile-suits")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetMobileSuits);
        app.MapGet("{id:int}", GetMobileSuitById);
        app.MapPost("", CreateMobileSuit);
        app.MapPut("{id:int}", UpdateMobileSuit);
        app.MapDelete("{id:int}", ToggleMobileSuit);
    }

    public async Task<IResult> GetMobileSuits(ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var mobileSuits = await context.MobileSuits
            .ProjectTo<MobileSuitResponse>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

         return Results.Ok(mobileSuits);
    }

    public async Task<IResult> GetMobileSuitById(int id, ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var mobileSuit = await context.MobileSuits
            .ProjectTo<MobileSuitResponse>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.MobileSuitId == id, cancellationToken);

        if (mobileSuit == null)
            return Results.NotFound();

        return Results.Ok(mobileSuit);
    }

    public async Task<IResult> CreateMobileSuit([FromBody] CreateMobileSuitRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var mobileSuit = MobileSuit.Create(request.MobileSuitName, request.MobileSuitUnitType, request.MobileSuitFirstSeen, request.MobileSuitLastSeen, request.ManufacturerId, request.SerieId);

        context.MobileSuits.Add(mobileSuit);

        await context.SaveChangesAsync(cancellationToken);

        foreach (var item in request.PilotIds)
        {
            var mobileSuitPilot = mobileSuit.AssignPilot(item);

            context.MobileSuitPilots.Add(mobileSuitPilot);
        }

        await context.SaveChangesAsync(cancellationToken);

        return Results.Created($"api/mobile-suits/{mobileSuit.MobileSuitId}", mobileSuit);
    }

    public async Task<IResult> UpdateMobileSuit(int id, [FromBody] UpdateMobileSuitRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        if (request.MobileSuitId != id)
            return Results.BadRequest("The mobile suit id in the request does not match the id in the route");

        var mobileSuit = await context.MobileSuits.FindAsync(new object[] { id }, cancellationToken);

        if (mobileSuit == null)
            return Results.NotFound();

        mobileSuit.Update(request.MobileSuitName, request.MobileSuitUnitType, request.MobileSuitFirstSeen, request.MobileSuitLastSeen, request.ManufacturerId, request.SerieId);

        var oldMobileSuitPilots = mobileSuit.MobileSuitPilots.ToList();

        foreach (var item in request.PilotIds)
        {
            var mobileSuitPilot = oldMobileSuitPilots.FirstOrDefault(x => x.CharacterId == item);

            if (mobileSuitPilot == null)
            {
                mobileSuitPilot = mobileSuit.AssignPilot(item);

                context.MobileSuitPilots.Add(mobileSuitPilot);
            }
            else
            {
                mobileSuitPilot.LastModified = DateTime.Now;
            }
        }

        foreach (var item in oldMobileSuitPilots)
        {
            if (!request.PilotIds.Contains(item.CharacterId))
            {
                context.MobileSuitPilots.Remove(item);
            }
        }

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok(mobileSuit);
    }

    public async Task<IResult> ToggleMobileSuit(int id, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var mobileSuit = await context.MobileSuits.FindAsync(new object[] { id }, cancellationToken);

        if (mobileSuit == null)
            return Results.NotFound();

        mobileSuit.ToggleActive();

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok();
    }
}
