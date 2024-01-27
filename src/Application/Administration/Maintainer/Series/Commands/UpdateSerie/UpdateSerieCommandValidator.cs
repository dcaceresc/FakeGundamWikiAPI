namespace Application.Administration.Maintainer.Series.Commands.UpdateSerie;
public class UpdateSerieCommandValidator : AbstractValidator<UpdateSerieCommand>
{
    public UpdateSerieCommandValidator()
    {
        RuleFor(v => v.SerieId)
            .NotEmpty().WithMessage("SerieId is required.");

        RuleFor(v => v.SerieName)
            .NotEmpty().WithMessage("SerieName is required.")
            .MaximumLength(200).WithMessage("SerieName must not exceed 200 characters.");

        RuleFor(v => v.UniverseId)
            .NotEmpty().WithMessage("UniverseId is required.");
    }
}
