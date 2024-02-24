namespace FakeGundamWikiAPI.Modules.Universes;

public class UniverseResponse : AuditableEntity
{
    public int UniverseId { get; set; }
    public string UniverseName { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Universe, UniverseResponse>();
        }
    }

}