namespace Application.Administration.Maintainer.Series.Queries.GetSeries;

public class SerieDto
{
    public int SerieId { get; set; }
    public string SerieName { get; set; } = null!;
    public string UniverseName { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SerieDto>()
                .ForMember(d => d.UniverseName, opt => opt.MapFrom(s => s.Universe.UniverseName));
        }
    }
}