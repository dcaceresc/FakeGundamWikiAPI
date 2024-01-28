namespace Application.Administration.Maintainer.Characters.Commands.ToggleCharacter;
public record ToggleCharacterCommand(int CharacterId) : IRequest;

public class ToggleCharacterCommandHandler(IApplicationDbContext context) : IRequestHandler<ToggleCharacterCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(ToggleCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await _context.Characters.FindAsync(new object[] { request.CharacterId }, cancellationToken);

        Guard.Against.NotFound(request.CharacterId, character);

        character.ToggleActive();

        await _context.SaveChangesAsync(cancellationToken);

    }
}

