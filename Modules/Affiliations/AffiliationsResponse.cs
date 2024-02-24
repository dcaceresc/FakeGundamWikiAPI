namespace FakeGundamWikiAPI.Modules.Affiliations;

public class AffiliationResponse : AuditableEntity
{
    public int AffiliationId { get; set; }
    public string AffiliationName { get; set; } = null!;
    public string AffiliationPurpose { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Affiliation, AffiliationResponse>();
        }
    }
}
