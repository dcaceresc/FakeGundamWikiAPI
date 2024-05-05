using Microsoft.AspNetCore.Authorization;

namespace FakeGundamWikiAPI.Areas.Maintainer.Controllers;

[Area("Maintainer")]
[Route("Maintainer/[controller]")]
[Authorize(Roles = "Administrator")]
public class ExampleTypesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
