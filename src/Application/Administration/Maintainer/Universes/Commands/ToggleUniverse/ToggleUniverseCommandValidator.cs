namespace Application.Administration.Maintainer.Universes.Commands.ToggleUniverse;
public class ToggleUniverseCommandValidator : AbstractValidator<ToggleUniverseCommand>
{
    public ToggleUniverseCommandValidator()
    {
        RuleFor(v => v.UniverseId)
            .NotEmpty().WithMessage("UniverseId is required.");
    }
}
