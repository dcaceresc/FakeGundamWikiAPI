namespace Application.Administration.Maintainer.MobileSuits.Commands.CreateMobileSuit;
public class CreateMobileSuitCommandValidator : AbstractValidator<CreateMobileSuitCommand>
{
    public CreateMobileSuitCommandValidator()
    {
        RuleFor(v => v.MobileSuitName)
            .NotEmpty().WithMessage("Mobile Suit Name is required.")
            .MaximumLength(200).WithMessage("Mobile Suit Name must not exceed 200 characters.");

        RuleFor(v => v.MobileSuitUnitType)
            .NotEmpty().WithMessage("Mobile Suit Unit Type is required.")
            .MaximumLength(200).WithMessage("Mobile Suit Unit Type must not exceed 200 characters.");

        RuleFor(v => v.MobileSuitFirstSeen)
            .NotEmpty().WithMessage("Mobile Suit First Seen is required.")
            .MaximumLength(200).WithMessage("Mobile Suit First Seen must not exceed 200 characters.");

        RuleFor(v => v.MobileSuitLastSeen)
            .NotEmpty().WithMessage("Mobile Suit Last Seen is required.")
            .MaximumLength(200).WithMessage("Mobile Suit Last Seen must not exceed 200 characters.");

        RuleFor(v => v.ManufacturerId)
            .NotEmpty().WithMessage("Manufacturer is required.");

        RuleFor(v => v.PilotIds)
            .NotEmpty().WithMessage("Pilot is required.");
    }
}
