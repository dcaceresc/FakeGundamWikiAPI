namespace WebApi.Modules.Maintainer;

public class MobileSuitsModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var mobileSuits = app.MapGroup("/api/mobile-suits");

        mobileSuits.MapGet("", GetMobileSuits);
    }

    private Task GetMobileSuits(HttpContext context)
    {
        throw new NotImplementedException();
    }
}
