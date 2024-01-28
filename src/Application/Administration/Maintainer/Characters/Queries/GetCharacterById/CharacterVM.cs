namespace Application.Administration.Maintainer.Characters.Queries.GetCharacterById;

public class CharacterVM
{
    public int CharacterId { get; set; }
    public string Aliases { get; set; } = null!;
    public string CharacterName { get; set; } = null!;
    public string Classification { get; set; } = null!;
    public string BirthDate { get; set; } = null!;
    public int GenderId { get; set; }
    public IList<int> AffiliationIds { get; set; } = null!;


    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Character, CharacterVM>()
                .ForMember(d => d.AffiliationIds, opt => opt.MapFrom(s => s.CharacterAffiliations.Select(x => x.AffiliationId)));
        }
    }
}