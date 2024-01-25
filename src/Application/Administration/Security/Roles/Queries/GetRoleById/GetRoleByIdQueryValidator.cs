namespace Application.Administration.Security.Roles.Queries.GetRoleById;
public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
{
    public GetRoleByIdQueryValidator()
    {
        RuleFor(v => v.RoleId)
            .NotEmpty().WithMessage("El id del permiso es requerido.");
    }
}
