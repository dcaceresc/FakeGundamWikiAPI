namespace Application.Security.Users.Commands.ToggleUser;
public class ToggleUserCommandValidator : AbstractValidator<ToggleUserCommand>
{
    public ToggleUserCommandValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty()
            .WithMessage("El id del usuario es requerido.");
    }
}
