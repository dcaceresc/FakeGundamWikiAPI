
namespace FakeGundamWikiAPI.Modules.Affiliations;

public class AffiliationsModule() : CarterModule("api/affiliations")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetAllAffiliations);
        app.MapGet("{id:int}", GetAffiliationById);
        app.MapPost("", CreateAffiliation);
        app.MapPut("{id:int}", UpdateAffiliation);
        app.MapDelete("{id:int}", ToggleAffiliation);
    }

    public async Task<IResult> GetAllAffiliations(ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var affiliations = await context.Affiliations
            .ProjectTo<AffiliationResponse>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Results.Ok(affiliations);
    }

    public async Task<IResult> GetAffiliationById(int id, ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var affiliation = await context.Affiliations
            .ProjectTo<AffiliationResponse>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(a => a.AffiliationId == id, cancellationToken);

        if (affiliation == null)
            return Results.NotFound();

        return Results.Ok(affiliation);
    }


    public async Task<IResult> CreateAffiliation([FromBody] CreateAffiliationRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var affiliation = Affiliation.Create(request.AffiliationName, request.AffiliationPurpose);

        context.Affiliations.Add(affiliation);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Created($"/api/affiliations/{affiliation.AffiliationId}", affiliation);
    }

    public async Task<IResult> UpdateAffiliation(int id, [FromBody] UpdateAffiliationRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        if (request.AffiliationId != id)
            return Results.BadRequest("The affiliation id in the request does not match the id in the route");

        var affiliation = await context.Affiliations.FindAsync(new object[] { id }, cancellationToken);

        if (affiliation == null)
            return Results.NotFound();

        affiliation.Update(request.AffiliationName, request.AffiliationPurpose);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok(affiliation);
    }

    public async Task<IResult> ToggleAffiliation(int id, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var affiliation = await context.Affiliations.FindAsync(new object[] { id }, cancellationToken);

        if (affiliation == null)
            return Results.NotFound();

        affiliation.ToggleActive();

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok();
    }
}
