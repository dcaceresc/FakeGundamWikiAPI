namespace Application.Administration.Maintainer.Affiliations.Commands.ToggleAffiliation;
public class ToggleAffiliationCommandValidator : AbstractValidator<ToggleAffiliationCommand>
{
    public ToggleAffiliationCommandValidator()
    {
        RuleFor(x => x.AffiliationId)
            .NotEmpty()
            .WithMessage("AffiliationId is required.");
    }
}
