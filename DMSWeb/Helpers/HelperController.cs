using Microsoft.AspNetCore.Mvc;

namespace DMSWeb.Helpers
{
    public class HelperController : Controller
    {
        public IActionResult GoToLogin(string success="false")
        {
            return RedirectToAction("Login","Admin", new { access = success});
        }

        public IActionResult GoToAdminHomePage()
        {
            return RedirectToAction("Index", "Admin");
        }
    }
}
