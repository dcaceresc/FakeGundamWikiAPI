namespace Application.Security.Roles.Commands.ToggleRole;
public class ToggleRoleCommandValidator : AbstractValidator<ToggleRoleCommand>
{
    public ToggleRoleCommandValidator()
    {
        RuleFor(v => v.RoleId)
            .NotEmpty().WithMessage("El id del permiso es requerido.");
    }
}
