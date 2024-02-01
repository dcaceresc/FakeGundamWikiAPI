using Application.Maintainer.Affiliations.Queries.GetAffiliations;

namespace Application.Maintainer.Characters.Queries.GetCharacters;

public class CharacterDto : AuditableEntity
{
    public int CharacterId { get; set; }
    public string Aliases { get; set; } = null!;
    public string CharacterName { get; set; } = null!;
    public string Classification { get; set; } = null!;
    public string BirthDate { get; set; } = null!;
    public int GenderId { get; set; }
    public IList<AffiliationDto> Affiliations { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Character, CharacterDto>()
                .ForMember(d => d.Affiliations, opt => opt.MapFrom(s => s.CharacterAffiliations.Select(x => new AffiliationDto
                {
                    AffiliationId = x.AffiliationId,
                    AffiliationName = x.Affiliation.AffiliationName,
                    AffiliationPurpose = x.Affiliation.AffiliationPurpose,
                    IsActive = x.Affiliation.IsActive,
                    CreatedBy = x.Affiliation.CreatedBy,
                    Created = x.Affiliation.Created,
                    LastModifiedBy = x.Affiliation.LastModifiedBy,
                    LastModified = x.Affiliation.LastModified
                }).ToList()));
        }
    }
}