using Application.Maintainer.Affiliations.Queries.GetAffiliations;
using Application.Maintainer.Characters.Queries.GetCharacters;
using Application.Maintainer.Manufacturers.Queries.GetManufacturers;
using Application.Maintainer.Series.Queries.GetSeries;

namespace Application.Maintainer.MobileSuits.Queries.GetMobileSuits;

public class MobileSuitDto : AuditableEntity
{
    public int MobileSuitId { get; set; }
    public string MobileSuitName { get; set; } = null!;
    public string MobileSuitUnitType { get; set; } = null!;
    public string MobileSuitFirstSeen { get; set; } = null!;
    public string MobileSuitLastSeen { get; set; } = null!;
    public ManufacturerDto Manufacturer { get; set; } = null!;
    public SerieDto Serie { get; set; } = null!;
    public IList<CharacterDto> MobileSuitPilots { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MobileSuit, MobileSuitDto>()
                .ForMember(d => d.Manufacturer, opt => opt.MapFrom(x => x.Manufacturer))
                .ForMember(d => d.Serie, opt => opt.MapFrom(x => x.Serie))
                .ForMember(d => d.MobileSuitPilots, opt => opt.MapFrom(x => x.MobileSuitPilots.Select(x => new CharacterDto
                {
                    CharacterId = x.CharacterId,
                    CharacterAliases = x.Character.CharacterAliases,
                    CharacterName = x.Character.CharacterName,
                    CharacterClassification = x.Character.CharacterClassification,
                    CharacterBirthDate = x.Character.CharacterBirthDate,
                    CharacterGenderId = x.Character.CharacterGenderId,
                    Affiliations = x.Character.CharacterAffiliations.Select(x => new AffiliationDto
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