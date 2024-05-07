namespace FakeGundamWikiAPI.Modules.Manufacturers;

public class ManufacturersModule() : CarterModule("api/manufacturers")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetManufacturers);
        app.MapGet("{id:int}", GetManufacturerById);
        app.MapPost("", CreateManufacturer);
        app.MapPut("{id:int}", UpdateManufacturer);
        app.MapDelete("{id:int}", ToggleManufacturer);
    }

    public async Task<IResult> GetManufacturers(ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var manufacturers = await context.Manufacturers
            .ProjectTo<ManufacturerResponse>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Results.Ok(manufacturers);
    }

    public async Task<IResult> GetManufacturerById(int id, ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var manufacturer = await context.Manufacturers
            .ProjectTo<ManufacturerResponse>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(m => m.ManufacturerId == id, cancellationToken);

        if (manufacturer == null)
            return Results.NotFound();

        return Results.Ok(manufacturer);
    }

    public async Task<IResult> CreateManufacturer([FromBody] CreateManufacturersRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var manufacturer = Manufacturer.Create(request.ManufacturerName);

        context.Manufacturers.Add(manufacturer);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Created($"api/manufacturers/{manufacturer.ManufacturerId}", manufacturer);

    }

    public async Task<IResult> UpdateManufacturer(int id, [FromBody] UpdateManufacturersRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        if (request.ManufacturerId != id)
            return Results.BadRequest("The manufacturer id in the request does not match the id in the route");

        var manufacturer = await context.Manufacturers.FindAsync([id], cancellationToken);

        if (manufacturer == null)
            return Results.NotFound();

        manufacturer.Update(request.ManufacturerName);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok(manufacturer);
    }

    public async Task<IResult> ToggleManufacturer(int id, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var manufacturer = await context.Manufacturers.FindAsync([id], cancellationToken);

        if (manufacturer == null)
            return Results.NotFound();

        manufacturer.ToggleActive();

        await context.SaveChangesAsync(cancellationToken);

        return Results.NoContent();
    }
}
