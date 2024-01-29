namespace Application.Administration.Maintainer.MobileSuits.Commands.ToggleMobileSuit;
public class ToggleMobileSuitCommandValidator : AbstractValidator<ToggleMobileSuitCommand>
{
    public ToggleMobileSuitCommandValidator()
    {
        RuleFor(v => v.MobileSuitId)
            .NotEmpty().WithMessage("Mobile Suit is required.");
    }
}
