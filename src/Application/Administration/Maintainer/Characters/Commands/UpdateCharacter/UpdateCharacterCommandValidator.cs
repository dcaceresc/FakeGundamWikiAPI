namespace Application.Administration.Maintainer.Characters.Commands.UpdateCharacter;
public class UpdateCharacterCommandValidator : AbstractValidator<UpdateCharacterCommand>
{
    public UpdateCharacterCommandValidator()
    {
        RuleFor(v => v.CharacterId)
            .NotEmpty().WithMessage("CharacterId is required.");

        RuleFor(v => v.Aliases)
            .NotEmpty().WithMessage("Aliases is required.")
            .MaximumLength(200).WithMessage("Aliases must not exceed 200 characters.");

        RuleFor(v => v.CharacterName)
            .NotEmpty().WithMessage("CharacterName is required.")
            .MaximumLength(200).WithMessage("CharacterName must not exceed 200 characters.");

        RuleFor(v => v.Classification)
            .NotEmpty().WithMessage("Classification is required.")
            .MaximumLength(200).WithMessage("Classification must not exceed 200 characters.");

        RuleFor(v => v.BirthDate)
            .NotEmpty().WithMessage("BirthDate is required.")
            .MaximumLength(200).WithMessage("BirthDate must not exceed 200 characters.");

        RuleFor(v => v.AffiliationsIds)
            .NotEmpty().WithMessage("AffiliationsIds is required.");

        RuleFor(v => v.GenderId)
            .NotEmpty().WithMessage("GenderId is required.");
    }
}
