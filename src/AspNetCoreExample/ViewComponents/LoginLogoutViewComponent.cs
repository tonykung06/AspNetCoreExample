using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreExample.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
