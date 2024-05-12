namespace FakeGundamWikiAPI.Areas.Security.Controllers;

[Area("Security")]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("Security/[controller]")]
public class UsersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
