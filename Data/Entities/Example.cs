namespace FakeGundamWikiAPI.Data.Entities;

public class Example : AuditableEntity
{
    public int ExampleId { get; set; }
    public string ExampleName { get; set; } = null!;
    public string ExampleCode { get; set; } = null!;
    public string? ExampleResult { get; set; }
    public int ExampleTypeId { get; set; }
    public ExampleType ExampleType { get; set; } = null!;
    public bool IsActive { get; set; }
}
