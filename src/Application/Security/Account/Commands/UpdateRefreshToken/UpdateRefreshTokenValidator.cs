namespace Application.Security.Account.Commands.UpdateRefreshToken;
public class UpdateRefreshTokenValidator : AbstractValidator<UpdateRefreshTokenCommand>
{
    public UpdateRefreshTokenValidator()
    {
        RuleFor(v => v.RefreshToken)
            .NotEmpty().WithMessage("El RefreshToken es requerido.")
            .MaximumLength(32).WithMessage("El RefreshToken no puede exceder los 30 caracteres.");
    }
}
