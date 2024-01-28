namespace Application.Administration.Maintainer.Characters.Commands.UpdateCharacter;
public record UpdateCharacterCommand : IRequest
{
    public int CharacterId { get; init; }
    public string Aliases { get; init; } = null!;
    public string CharacterName { get; init; } = null!;
    public string Classification { get; init; } = null!;
    public string BirthDate { get; init; } = null!;
    public int GenderId { get; init; }
    public IList<int> AffiliationsIds { get; init; } = null!;
}

public class UpdateCharacterCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateCharacterCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await _context.Characters.FindAsync(new object[] { request.CharacterId }, cancellationToken);

        Guard.Against.NotFound(request.CharacterId, character);

        character.Update(request.Aliases, request.CharacterName, request.Classification, request.BirthDate, request.GenderId);

        await _context.SaveChangesAsync(cancellationToken);

        var oldCharacterAffiliations = await _context.CharacterAffiliations.Where(x => x.CharacterId == request.CharacterId).ToListAsync(cancellationToken);

        foreach (var item in request.AffiliationsIds)
        {
            var exitingCharacterAffiliation = oldCharacterAffiliations.FirstOrDefault(x => x.AffiliationId == item);

            if (exitingCharacterAffiliation == null)
            {
                var characterAffiliation = character.AssignAffiliation(item);

                await _context.CharacterAffiliations.AddAsync(characterAffiliation, cancellationToken);
            }
            else
            {
                exitingCharacterAffiliation.LastModified = DateTime.Now;
            }
        }

        foreach (var item in oldCharacterAffiliations)
        {
            if (!request.AffiliationsIds.Contains(item.AffiliationId))
            {
                _context.CharacterAffiliations.Remove(item);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

    }
}