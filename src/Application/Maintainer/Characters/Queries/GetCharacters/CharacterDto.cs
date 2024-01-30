namespace Application.Maintainer.Characters.Queries.GetCharacters;

public class CharacterDto
{
    public int CharacterId { get; set; }
    public string Aliases { get; set; } = null!;
    public string CharacterName { get; set; } = null!;
    public string Classification { get; set; } = null!;
    public string BirthDate { get; set; } = null!;
    public int GenderId { get; set; }
    public IList<string> AffiliationNames { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Character, CharacterDto>()
                .ForMember(d => d.AffiliationNames, opt => opt.MapFrom(s => s.CharacterAffiliations.Select(x => x.Affiliation.AffiliationName)));
        }
    }
}