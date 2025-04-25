using FakeGundamWikiAPI.Models;
using System.Diagnostics;

namespace FakeGundamWikiAPI.Controllers;
public class HomeController(ILogger<HomeController> logger) : BaseController
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Offline()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
