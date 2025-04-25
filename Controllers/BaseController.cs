using Microsoft.AspNetCore.Mvc.Filters;

namespace FakeGundamWikiAPI.Controllers;
public abstract class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        if (!SiteConfig.SiteStatus)
        {
            context.Result = RedirectToAction("Offline", "Home");
        }
    }
}
