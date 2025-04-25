using FakeGundamWikiAPI.Areas.Security.Models.Account;
using FakeGundamWikiAPI.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FakeGundamWikiAPI.Areas.Security.Controllers;

[Area("Security")]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("Security/[controller]")]
public class AccountController(Services.AuthenticationService authenticationService, ApplicationDbContext context) : BaseController
{
    private readonly Services.AuthenticationService _authenticationService = authenticationService;
    private readonly ApplicationDbContext _context = context;

    [HttpGet("/admin")]
    public IActionResult AdminLogin()
    {
        if (User.Identity!.IsAuthenticated)
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdminLogin(AdminLoginRequest request)
    {
        var admin = await _context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.UserName == request.Username &&
                                      u.UserRoles.Any(ur => ur.Role.RoleName == "Administrator"));

        if (admin == null)
        {
            ModelState.AddModelError("Username", "Invalid username or you do not have administrator privileges.");
            return View();
        }

        var isValid = _authenticationService.VerifyPassword(request.Password, admin.HashPassword);

        if (!isValid)
        {
            ModelState.AddModelError("Password", "Invalid password.");
            return View();
        }

        await _authenticationService.CreateCookie(request.Username, ["Administrator"]);

        return RedirectToAction("Index", "Configurations", new { area = "Maintainer" });
    }

    [HttpGet("Logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
