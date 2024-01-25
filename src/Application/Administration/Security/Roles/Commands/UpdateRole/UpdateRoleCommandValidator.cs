namespace Application.Administration.Security.Roles.Commands.UpdateRole;
public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(v => v.RoleId)
            .NotEmpty().WithMessage("El id del permiso es requerido.");

        RuleFor(v => v.RoleName)
            .NotEmpty().WithMessage("El nombre del permiso es requerido.")
            .MaximumLength(30).WithMessage("El nombre del permiso no puede exceder los 30 caracteres.");
    }
}
