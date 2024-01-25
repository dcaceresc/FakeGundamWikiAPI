namespace Application.Administration.Security.Account.Commands.CreateTokens;
public class CreateTokensCommandValidator : AbstractValidator<CreateTokensCommand>
{
    public CreateTokensCommandValidator()
    {
        RuleFor(v => v.UserName)
            .NotEmpty().WithMessage("El nombre de usuario es requerido.")
            .MaximumLength(30).WithMessage("El nombre de usuario no puede exceder los 30 caracteres.");
    }
}