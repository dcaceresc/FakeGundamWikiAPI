namespace FakeGundamWikiAPI.Areas.Maintainer.Models.Examples;


public class CreateExampleRequest
{
    public string ExampleName { get; set; } = null!;
    public string ExampleCode { get; set; } = null!;
    public string? ExampleResult { get; set; }
    public int ExampleTypeId { get; set; }
}

public class EditExampleRequest
{
    public int ExampleId { get; set; }
    public string ExampleName { get; set; } = null!;
    public string ExampleCode { get; set; } = null!;
    public string? ExampleResult { get; set; }
    public int ExampleTypeId { get; set; }
}