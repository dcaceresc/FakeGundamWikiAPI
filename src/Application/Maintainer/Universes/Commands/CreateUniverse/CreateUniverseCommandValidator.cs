namespace Application.Maintainer.Universes.Commands.CreateUniverse;
public class CreateUniverseCommandValidator : AbstractValidator<CreateUniverseCommand>
{
    public CreateUniverseCommandValidator()
    {
        RuleFor(v => v.UniverseName)
            .NotEmpty().WithMessage("UniverseName is required.")
            .MaximumLength(200).WithMessage("UniverseName must not exceed 200 characters.");
    }
}
