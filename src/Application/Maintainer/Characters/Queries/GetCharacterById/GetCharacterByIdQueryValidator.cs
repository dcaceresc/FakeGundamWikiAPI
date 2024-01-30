namespace Application.Maintainer.Characters.Queries.GetCharacterById;
public class GetCharacterByIdQueryValidator : AbstractValidator<GetCharacterByIdQuery>
{
    public GetCharacterByIdQueryValidator()
    {
        RuleFor(v => v.CharacterId)
            .NotEmpty().WithMessage("CharacterId is required.");
    }
}
