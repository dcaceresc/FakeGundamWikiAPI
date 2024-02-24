using FakeGundamWikiAPI.Modules.Affiliations;

namespace FakeGundamWikiAPI.Modules.Characters;

public class CharacterResponse : AuditableEntity
{
    public int CharacterId { get; set; }
    public string CharacterName { get; set; } = null!;
    public string CharacterAliases { get; set; } = null!;
    public string CharacterClassification { get; set; } = null!;
    public string CharacterBirthDate { get; set; } = null!;
    public int CharacterGenderId { get; set; }
    public IList<AffiliationResponse> Affiliations { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Character, CharacterResponse>()
                .ForMember(dest => dest.Affiliations, opt => opt.MapFrom(src => src.CharacterAffiliations.Select(ca => ca.Affiliation).Select(x => new AffiliationResponse
                {
                    AffiliationId = x.AffiliationId,
                    AffiliationName = x.AffiliationName,
                    AffiliationPurpose = x.AffiliationPurpose,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    Created = x.Created,
                    LastModifiedBy = x.LastModifiedBy,
                    LastModified = x.LastModified
                }).ToList()));
        }
    }
}
