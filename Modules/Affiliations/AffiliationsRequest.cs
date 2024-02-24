namespace FakeGundamWikiAPI.Modules.Affiliations;

public class CreateAffiliationRequest
{
    public string AffiliationName { get; set; } = null!;
    public string AffiliationPurpose { get; set; } = null!;
}

public class UpdateAffiliationRequest
{
    public int AffiliationId { get; set; }
    public string AffiliationName { get; set; } = null!;
    public string AffiliationPurpose { get; set; } = null!;
}