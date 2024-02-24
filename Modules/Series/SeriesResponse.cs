using FakeGundamWikiAPI.Modules.Universes;

namespace FakeGundamWikiAPI.Modules.Series;

public class SerieResponse : AuditableEntity
{
    public int SerieId { get; set; }
    public string SerieName { get; set; } = null!;
    public UniverseResponse Universe { get; set; } = null!;
    public bool IsActive { get; set; }
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SerieResponse>()
                .ForMember(d => d.Universe, opt => opt.MapFrom(s => s.Universe));
        }
    }
}
