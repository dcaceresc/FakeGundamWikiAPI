namespace Application.Security.Account.Commands.UserLogin;
public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
{
    public UserLoginCommandValidator()
    {
        RuleFor(v => v.UserName)
            .NotEmpty().WithMessage("El nombre de usuario es requerido.")
            .MaximumLength(30).WithMessage("El nombre de usuario no puede exceder los 30 caracteres.");

        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("La contraseña es requerida.")
            .MaximumLength(30).WithMessage("La contraseña no puede exceder los 30 caracteres.");
    }
}
