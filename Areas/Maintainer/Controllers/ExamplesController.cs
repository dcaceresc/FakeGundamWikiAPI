using Microsoft.AspNetCore.Authorization;

namespace FakeGundamWikiAPI.Areas.Maintainer.Controllers;

[Area("Maintainer")]
[Route("Maintainer/[controller]")]
[Authorize(Roles = "Administrator")]
public class ExamplesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
