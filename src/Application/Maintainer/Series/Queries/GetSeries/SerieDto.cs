using Application.Maintainer.Universes.Queries.GetUniverses;

namespace Application.Maintainer.Series.Queries.GetSeries;

public class SerieDto : AuditableEntity
{
    public int SerieId { get; set; }
    public string SerieName { get; set; } = null!;
    public UniverseDto Universe { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SerieDto>()
                .ForMember(d => d.Universe, opt => opt.MapFrom(s => s.Universe));
        }
    }
}