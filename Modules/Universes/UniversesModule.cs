namespace FakeGundamWikiAPI.Modules.Universes;

public class UniversesModule() : CarterModule()
{

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/universes")
            .RequireAuthorization(new AuthorizeAttribute
            {
                AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
            });

        group.MapGet("", GetUniverses);
        group.MapGet("{id:int}", GetUniverseById);
        group.MapPost("", CreateUniverse);
        group.MapPut("{id:int}", UpdateUniverse);
        group.MapDelete("{id:int}", ToggleUniverse);

    }

    public async Task<IResult> GetUniverses(ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var universes = await context.Universes
            .ProjectTo<UniverseResponse>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Results.Ok(universes);
    }

    public async Task<IResult> GetUniverseById(int id, ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var universe = await context.Universes
            .ProjectTo<UniverseResponse>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.UniverseId == id, cancellationToken);

        if (universe == null)
            return Results.NotFound();

        return Results.Ok(universe);
    }

    public async Task<IResult> CreateUniverse([FromBody] CreateUniverseRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var universe = Universe.Create(request.UniverseName);

        context.Universes.Add(universe);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Created($"api/universes/{universe.UniverseId}", universe);

    }

    public async Task<IResult> UpdateUniverse(int id, [FromBody] UpdateUniverseRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        if (request.UniverseId != id)
            return Results.BadRequest("The universe id in the request does not match the id in the route");

        var universe = await context.Universes.FindAsync([id], cancellationToken);

        if (universe == null)
            return Results.NotFound();

        universe.Update(request.UniverseName);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok(universe);
    }

    public async Task<IResult> ToggleUniverse(int id, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var universe = await context.Universes.FindAsync([id], cancellationToken);

        if (universe == null)
            return Results.NotFound();

        universe.ToggleActive();

        await context.SaveChangesAsync(cancellationToken);

        return Results.NoContent();
    }
}
