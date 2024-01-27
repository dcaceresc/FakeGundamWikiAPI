namespace Application.Administration.Maintainer.Series.Queries.GetSerieById;

public class SerieVM
{
    public int SerieId { get; set; }
    public string SerieName { get; set; } = null!;
    public int UniverseId { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SerieVM>();
        }
    }
}