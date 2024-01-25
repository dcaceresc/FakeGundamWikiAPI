namespace Application.Administration.Security.Users.Commands.UpdateUser;
public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty()
            .WithMessage("El id de usuario es requerido.");

        RuleFor(v => v.UserName)
            .NotEmpty()
            .WithMessage("El nombre de usuario es requerido.")
            .MaximumLength(30).WithMessage("El nombre de usuario no puede exceder los 30 caracteres.");

        RuleFor(v => v.FirstName)
            .NotEmpty()
            .WithMessage("El nombre es requerido.")
            .MaximumLength(30).WithMessage("El nombre no puede exceder los 30 caracteres.");

        RuleFor(v => v.LastName)
            .NotEmpty()
            .WithMessage("El apellido es requerido.")
            .MaximumLength(30).WithMessage("El apellido no puede exceder los 30 caracteres.");

        RuleFor(v => v.RolesId)
            .NotEmpty()
            .WithMessage("Los roles son requeridos.");
    }
}
