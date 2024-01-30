namespace Application.Maintainer.Series.Commands.ToggleSerie;
public class ToggleSerieCommandValidator : AbstractValidator<ToggleSerieCommand>
{
    public ToggleSerieCommandValidator()
    {
        RuleFor(v => v.SerieId)
            .NotEmpty().WithMessage("SerieId is required.");
    }
}
