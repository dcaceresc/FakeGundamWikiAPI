namespace Application.Administration.Security.Account.Commands.AdminLogin;
public class AdminLoginCommandValidator : AbstractValidator<AdminLoginCommand>
{
    public AdminLoginCommandValidator()
    {
        RuleFor(v => v.UserName)
            .NotEmpty().WithMessage("El nombre de usuario es requerido.")
            .MaximumLength(30).WithMessage("El nombre de usuario no puede exceder los 30 caracteres.");

        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("La contraseña es requerida.")
            .MaximumLength(30).WithMessage("La contraseña no puede exceder los 30 caracteres.");

        RuleFor(v => v.Supplanted)
            .NotEmpty().WithMessage("La cuenta es requerido.")
            .MaximumLength(30).WithMessage("La cuenta no puede exceder los 30 caracteres.");
    }
}
