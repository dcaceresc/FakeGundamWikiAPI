namespace FakeGundamWikiAPI.Areas.Maintainer.Models.ExampleTypes;

public class CreateExampleTypeRequest
{
    public string ExampleTypeName { get; set; } = null!;
}

public class EditExampleTypeRequest
{
    public int ExampleTypeId { get; set; }
    public string ExampleTypeName { get; set; } = null!;
}