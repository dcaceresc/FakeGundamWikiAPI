namespace Application.Administration.Maintainer.Universes.Queries.GetUniverseById;

public class UniverseVM
{
    public int UniverseId { get; set; }
    public string UniverseName { get; set; } = null!;

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Universe, UniverseVM>();
        }
    }
}