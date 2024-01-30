namespace Application.Maintainer.Manufacturers.Commands.UpdateManufacturer;
public class UpdateManufacturerCommandValidator : AbstractValidator<UpdateManufacturerCommand>
{
    public UpdateManufacturerCommandValidator()
    {
        RuleFor(x => x.ManufacturerId)
            .NotEmpty()
            .WithMessage("ManufacturerId is required.");

        RuleFor(x => x.ManufacturerName)
            .NotEmpty()
            .WithMessage("ManufacturerName is required.")
            .MaximumLength(50)
            .WithMessage("ManufacturerName must not exceed 50 characters.");
    }
}
