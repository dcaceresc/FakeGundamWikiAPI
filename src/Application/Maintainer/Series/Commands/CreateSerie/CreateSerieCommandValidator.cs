namespace Application.Maintainer.Series.Commands.CreateSerie;
public class CreateSerieCommandValidator : AbstractValidator<CreateSerieCommand>
{
    public CreateSerieCommandValidator()
    {
        RuleFor(v => v.SerieName)
            .NotEmpty().WithMessage("SerieName is required.")
            .MaximumLength(200).WithMessage("SerieName must not exceed 200 characters.");

        RuleFor(v => v.UniverseId)
            .NotEmpty().WithMessage("UniverseId is required.");
    }
}
