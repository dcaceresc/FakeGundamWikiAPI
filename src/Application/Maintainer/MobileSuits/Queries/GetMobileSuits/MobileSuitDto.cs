using Application.Maintainer.Characters.Queries.GetCharacters;
using Application.Maintainer.Manufacturers.Queries.GetManufacturers;

namespace Application.Maintainer.MobileSuits.Queries.GetMobileSuits;

public class MobileSuitDto
{
    public int MobileSuitId { get; set; }
    public string MobileSuitName { get; set; } = null!;
    public string MobileSuitUnitType { get; set; } = null!;
    public string MobileSuitFirstSeen { get; set; } = null!;
    public string MobileSuitLastSeen { get; set; } = null!;
    public ManufacturerDto Manufacturers { get; set; } = null!;
    public IList<CharacterDto> MobileSuitPilots { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MobileSuit, MobileSuitDto>()
                .ForMember(d => d.Manufacturers, opt => opt.MapFrom(x => x.Manufacturer))
                .ForMember(d => d.MobileSuitPilots, opt => opt.MapFrom(x => x.MobileSuitPilots.Select(x => new CharacterDto
                {
                    CharacterId = x.CharacterId,
                    Aliases = x.Character.Aliases,
                    CharacterName = x.Character.CharacterName,
                    Classification = x.Character.Classification,
                    BirthDate = x.Character.BirthDate,
                    GenderId = x.Character.GenderId,
                    IsActive = x.Character.IsActive,
                    CreatedBy = x.Character.CreatedBy,
                    Created = x.Character.Created,
                    LastModifiedBy = x.Character.LastModifiedBy,
                    LastModified = x.Character.LastModified
                }).ToList()));
        }
    }
}