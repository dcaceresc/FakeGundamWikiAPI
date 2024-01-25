namespace Application.Administration.Security.Roles.Commands.CreateRole;
public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(v => v.RoleName)
            .NotEmpty().WithMessage("El nombre del permiso es requerido.")
            .WithMessage("El nombre del permiso no puede exceder los 30 caracteres.");
    }
}
