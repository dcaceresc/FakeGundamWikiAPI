namespace FakeGundamWikiAPI.Modules.Characters;

public class CharactersModule() : CarterModule("api/characters")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetCharacters);
        app.MapGet("{id:int}", GetCharacterById);
        app.MapPost("", CreateCharacter);
        app.MapPut("{id:int}", UpdateCharacter);
        app.MapDelete("{id:int}", ToggleCharacter);
    }

    private async Task<IResult> GetCharacters(ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var characters = await context.Characters
            .Include(x => x.CharacterAffiliations)
            .ThenInclude(x => x.Affiliation)
            .ProjectTo<CharacterResponse>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Results.Ok(characters);
    }

    private async Task<IResult> GetCharacterById(int id, ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var character = await context.Characters
            .Include(x => x.CharacterAffiliations)
            .ThenInclude(x => x.Affiliation)
            .ProjectTo<CharacterResponse>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.CharacterId == id, cancellationToken);

        if (character == null)
            Results.NotFound();

        return Results.Ok(character);
    }

    private async Task<IResult> CreateCharacter([FromBody] CreateCharacterRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var character = Character.Create(request.CharacterName, request.CharacterAliases, request.CharacterClassification, request.CharacterBirthDate, request.CharacterGenderId);

        context.Characters.Add(character);

        await context.SaveChangesAsync(cancellationToken);

        foreach (var item in request.AffiliationIds)
        {
            var characterAffiliation = character.AssignAffiliation(item);

            context.CharacterAffiliations.Add(characterAffiliation);
        }

        await context.SaveChangesAsync(cancellationToken);

        return Results.Created($"/api/characters/{character.CharacterId}", character);
    }

    private async Task<IResult> UpdateCharacter(int id, [FromBody] UpdateCharacterRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        if (request.CharacterId != id)
            return Results.BadRequest("The character id in the request does not match the id in the route");

        var character = await context.Characters.FindAsync(new object[] { id }, cancellationToken);

        if (character == null)
            return Results.NotFound();

        character.Update(request.CharacterName, request.CharacterAliases, request.CharacterClassification, request.CharacterBirthDate, request.CharacterGenderId);

        var oldCharacterAffiliations = await context.CharacterAffiliations.Where(x => x.CharacterId == request.CharacterId).ToListAsync(cancellationToken);

        foreach (var item in request.AffiliationIds)
        {
            var exitingCharacterAffiliation = oldCharacterAffiliations.FirstOrDefault(x => x.AffiliationId == item);

            if (exitingCharacterAffiliation == null)
            {
                var characterAffiliation = character.AssignAffiliation(item);

                await context.CharacterAffiliations.AddAsync(characterAffiliation, cancellationToken);
            }
            else
            {
                exitingCharacterAffiliation.LastModified = DateTime.Now;
            }
        }

        foreach (var item in oldCharacterAffiliations)
        {
            if (!request.AffiliationIds.Contains(item.AffiliationId))
            {
                context.CharacterAffiliations.Remove(item);
            }
        }

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok(character);
    }

    private async Task<IResult> ToggleCharacter(int id, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var character = await context.Characters.FindAsync(new object[] { id }, cancellationToken);

        if (character == null)
            return Results.NotFound();

        character.ToggleActive();

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok();
    }
}
