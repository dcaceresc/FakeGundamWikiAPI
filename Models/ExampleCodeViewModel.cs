using FakeGundamWikiAPI.Areas.Maintainer.Models.Examples;

namespace FakeGundamWikiAPI.Models;

public class ExampleCodeViewModel
{
    private ExampleCodeViewModel(string id, IList<ExampleDto> examples)
    {
        Id = id;
        Code = examples.Where(x => x.ExampleName == id).First().ExampleCode;
        JsonResponse = examples.Where(x => x.ExampleName == id).First().ExampleResult;
    }


    public string Id { get; private set; } = null!;
    public string Code { get; private set; } = null!;
    public string? JsonResponse { get; private set; }


    public static ExampleCodeViewModel Create(string id, IList<ExampleDto> examples)
    {
        return new ExampleCodeViewModel(id, examples);
    }
}
