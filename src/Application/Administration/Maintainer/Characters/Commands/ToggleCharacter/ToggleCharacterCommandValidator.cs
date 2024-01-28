namespace Application.Administration.Maintainer.Characters.Commands.ToggleCharacter;
public class ToggleCharacterCommandValidator : AbstractValidator<ToggleCharacterCommand>
{
    public ToggleCharacterCommandValidator()
    {
        RuleFor(v => v.CharacterId)
            .NotEmpty().WithMessage("CharacterId is required.");
    }
}
