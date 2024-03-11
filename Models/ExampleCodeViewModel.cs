namespace FakeGundamWikiAPI.Models;

public class ExampleCodeViewModel
{
    private ExampleCodeViewModel(string id, string code, string jsonResponse)
    {
        Id = id;
        Code = code;
        JsonResponse = jsonResponse;
    }


    public string Id { get; private set; } = null!;
    public string Code { get; private set; } = null!;
    public string JsonResponse { get; private set; } = null!;


    public static ExampleCodeViewModel Create(string id,string code, string jsonResponse)
    {
        return new ExampleCodeViewModel(id ,code, jsonResponse);
    }
}
