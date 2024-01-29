namespace Application.Administration.Maintainer.Manufacturers.Commands.CreateManufacturer;
public class CreateManufacturerCommandValidator : AbstractValidator<CreateManufacturerCommand>
{
    public CreateManufacturerCommandValidator()
    {
        RuleFor(v => v.ManufacturerName)
            .NotEmpty()
            .WithMessage("ManufacturerName is required.")
            .MaximumLength(50)
            .WithMessage("ManufacturerName must not exceed 50 characters.");
    }
}
