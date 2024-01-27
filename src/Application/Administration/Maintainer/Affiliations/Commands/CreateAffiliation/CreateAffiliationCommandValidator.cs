namespace Application.Administration.Maintainer.Affiliations.Commands.CreateAffiliation;
public class CreateAffiliationCommandValidator : AbstractValidator<CreateAffiliationCommand>
{
    public CreateAffiliationCommandValidator()
    {
        RuleFor(v => v.AffiliationName)
            .NotEmpty().WithMessage("AffiliationName is required.")
            .MaximumLength(200).WithMessage("AffiliationName must not exceed 200 characters.");

        RuleFor(v => v.AffiliationPurpuse)
            .NotEmpty().WithMessage("AffiliationPurpuse is required.")
            .MaximumLength(200).WithMessage("AffiliationPurpuse must not exceed 200 characters.");
    }
}
