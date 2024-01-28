namespace Application.Administration.Maintainer.Affiliations.Queries.GetAffiliantionById;
public class GetAffiliationByIdQueryValidator : AbstractValidator<GetAffiliantionByIdQuery>
{
    public GetAffiliationByIdQueryValidator()
    {
        RuleFor(x => x.AffiliantionId)
            .NotEmpty()
            .WithMessage("El id de la afiliación es requerido.");
    }
}
