namespace Application.Maintainer.Universes.Commands.UpdateUniverse;
public class UpdateUniverseCommandValidator : AbstractValidator<UpdateUniverseCommand>
{
    public UpdateUniverseCommandValidator()
    {
        RuleFor(v => v.UniverseId)
            .NotEmpty().WithMessage("UniverseId is required.");

        RuleFor(v => v.UniverseName)
            .NotEmpty().WithMessage("UniverseName is required.")
            .MaximumLength(200).WithMessage("UniverseName must not exceed 200 characters.");
    }
}
