using Microsoft.AspNetCore.Mvc;

namespace DMSWeb.Helpers
{
    public class HelperController : Controller
    {
        public IActionResult GoToLogin(string message)
        {
            ViewBag.Message = message;
            return RedirectToAction("Login","Admin");
        }

        public IActionResult GoToHomePage()
        {
            return RedirectToAction("Index", "Admin");
        }
    }
}
