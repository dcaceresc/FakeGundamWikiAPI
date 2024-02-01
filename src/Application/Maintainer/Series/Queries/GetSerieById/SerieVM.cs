using Application.Maintainer.Universes.Queries.GetUniverses;

namespace Application.Maintainer.Series.Queries.GetSerieById;

public class SerieVM : AuditableEntity
{
    public int SerieId { get; set; }
    public string SerieName { get; set; } = null!;
    public UniverseDto Universe { get; set; } = null!;

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SerieVM>()
                .ForMember(d => d.Universe, opt => opt.MapFrom(s => s.Universe));
        }
    }
}