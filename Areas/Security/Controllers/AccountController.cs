using FakeGundamWikiAPI.Areas.Security.Models.Account;

namespace FakeGundamWikiAPI.Areas.Security.Controllers;

[Area("Security")]
[Route("Security/[controller]")]
public class AccountController(ApplicationDbContext context, AuthenticationService authenticationService) : Controller
{
    private readonly ApplicationDbContext _context = context;
    private readonly AuthenticationService _authenticationService = authenticationService;

    [HttpGet("/admin")]
    public IActionResult AdminLogin()
    {
        // agrega un if si esta logueado ir a home

        if (User.Identity!.IsAuthenticated)
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdminLogin(AdminLoginRequest request)
    {
        var admin = _context
            .Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .Where(x => x.UserName == request.Username && x.Password == request.Password && x.UserRoles.Any(ur => ur.Role.RoleName == "Administrator"))
            .FirstOrDefault();

        if (admin == null)
        {
            ModelState.AddModelError("Username", "Invalid username or password");
            return View();
        }

        await _authenticationService.CreateCookie(admin.UserName, ["Administrator"]);

        return RedirectToAction("Index", "Examples", new { area = "Maintainer" });
    }
}
