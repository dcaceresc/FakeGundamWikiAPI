namespace Application.Maintainer.Universes.Queries.GetUniverseById;
public class GetUniverseByIdQueryValidator : AbstractValidator<GetUniverseByIdQuery>
{
    public GetUniverseByIdQueryValidator()
    {
        RuleFor(v => v.UniverseId)
            .NotEmpty().WithMessage("UniverseId is required.");
    }
}
