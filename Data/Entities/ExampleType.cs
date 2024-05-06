namespace FakeGundamWikiAPI.Data.Entities;

public class ExampleType : AuditableEntity
{
    public int ExampleTypeId { get; set; }
    public string ExampleTypeName { get; set; } = null!;
    public bool IsActive { get; set; }

    public ICollection<Example> Examples { get; set; } = null!;
}
