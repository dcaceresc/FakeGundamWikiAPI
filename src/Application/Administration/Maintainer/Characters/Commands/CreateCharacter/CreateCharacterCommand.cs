namespace Application.Administration.Maintainer.Characters.Commands.CreateCharacter;
public record CreateCharacterCommand : IRequest<int>
{
    public string Aliases { get; init; } = null!;
    public string CharacterName { get; init; } = null!;
    public string Classification { get; init; } = null!;
    public string BirthDate { get; init; } = null!;
    public IList<int> AffiliationsIds { get; init; } = null!;
    public int GenderId { get; init; }
}

public class CreateCharacterCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateCharacterCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = Character.Create(request.Aliases, request.CharacterName, request.Classification, request.BirthDate, request.GenderId);

        _context.Characters.Add(character);

        await _context.SaveChangesAsync(cancellationToken);

        foreach (var item in request.AffiliationsIds)
        {
            var characterAffiliation = character.AssignAffiliation(item);

            _context.CharacterAffiliations.Add(characterAffiliation);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return character.CharacterId;
    }
}
