using Microsoft.AspNetCore.Mvc;

namespace FakeGundamWikiAPI.Controllers;
public class DocsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
