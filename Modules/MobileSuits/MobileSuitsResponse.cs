using FakeGundamWikiAPI.Modules.Affiliations;
using FakeGundamWikiAPI.Modules.Characters;
using FakeGundamWikiAPI.Modules.Manufacturers;
using FakeGundamWikiAPI.Modules.Series;

namespace FakeGundamWikiAPI.Modules.MobileSuits;

public class MobileSuitResponse : AuditableEntity
{
    public int MobileSuitId { get; set; }
    public string MobileSuitName { get; set; } = null!;
    public string MobileSuitUnitType { get; set; } = null!;
    public string MobileSuitFirstSeen { get; set; } = null!;
    public string MobileSuitLastSeen { get; set; } = null!;
    public ManufacturerResponse Manufacturer { get; set; } = null!;
    public SerieResponse Serie { get; set; } = null!;
    public IList<CharacterResponse> Pilots { get; set; } = null!;

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MobileSuit, MobileSuitResponse>()
                 .ForMember(d => d.Manufacturer, opt => opt.MapFrom(x => x.Manufacturer))
                 .ForMember(d => d.Serie, opt => opt.MapFrom(x => x.Serie))
                 .ForMember(d => d.Pilots, opt => opt.MapFrom(x => x.MobileSuitPilots.Select(x => new CharacterResponse
                 {
                     CharacterId = x.CharacterId,
                     CharacterAliases = x.Character.CharacterAliases,
                     CharacterName = x.Character.CharacterName,
                     CharacterClassification = x.Character.CharacterClassification,
                     CharacterBirthDate = x.Character.CharacterBirthDate,
                     CharacterGenderId = x.Character.CharacterGenderId,
                     Affiliations = x.Character.CharacterAffiliations.Select(x => new AffiliationResponse
                     {
                         AffiliationId = x.AffiliationId,
                         AffiliationName = x.Affiliation.AffiliationName,
                         AffiliationPurpose = x.Affiliation.AffiliationPurpose,
                         IsActive = x.Affiliation.IsActive,
                         CreatedBy = x.Affiliation.CreatedBy,
                         Created = x.Affiliation.Created,
                         LastModifiedBy = x.Affiliation.LastModifiedBy,
                         LastModified = x.Affiliation.LastModified
                     }).ToList(),
                     IsActive = x.Character.IsActive,
                     CreatedBy = x.Character.CreatedBy,
                     Created = x.Character.Created,
                     LastModifiedBy = x.Character.LastModifiedBy,
                     LastModified = x.Character.LastModified
                 }).ToList()));
        }
    }
}
