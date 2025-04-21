using FakeGundamWikiAPI.Areas.Security.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FakeGundamWikiAPI.Areas.Security.Controllers;

[Area("Security")]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("Security/[controller]")]
public class AccountController(Services.AuthenticationService authenticationService) : Controller
{
    private readonly Services.AuthenticationService _authenticationService = authenticationService;

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
        var admin = SiteConfig.SuperAdminUserName == request.Username && SiteConfig.SuperAdminPassword == request.Password;

        if (!admin)
        {
            ModelState.AddModelError("Username", "Invalid username");
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
