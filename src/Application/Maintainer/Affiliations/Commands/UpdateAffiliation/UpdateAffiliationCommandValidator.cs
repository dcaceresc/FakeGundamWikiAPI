namespace Application.Maintainer.Affiliations.Commands.UpdateAffiliation;
public class UpdateAffiliationCommandValidator : AbstractValidator<UpdateAffiliationCommand>
{
    public UpdateAffiliationCommandValidator()
    {
        RuleFor(x => x.AffiliationId)
            .NotEmpty()
            .WithMessage("AffiliationId is required.");

        RuleFor(x => x.AffiliationName)
            .NotEmpty()
            .WithMessage("AffiliationName is required.")
            .MaximumLength(100)
            .WithMessage("El nombre de la afiliación no debe exceder los 100 caracteres.");

        RuleFor(x => x.AffiliationPurpose)
            .NotEmpty()
            .WithMessage("AffiliationPurpose is required.")
            .MaximumLength(100)
            .WithMessage("El propósito de la afiliación no debe exceder los 100 caracteres.");
    }
}

