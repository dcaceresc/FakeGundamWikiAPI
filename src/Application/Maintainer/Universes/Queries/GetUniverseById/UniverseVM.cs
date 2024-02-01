namespace Application.Maintainer.Universes.Queries.GetUniverseById;

public class UniverseVM : AuditableEntity
{
    public int UniverseId { get; set; }
    public string UniverseName { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Universe, UniverseVM>();
        }
    }
}