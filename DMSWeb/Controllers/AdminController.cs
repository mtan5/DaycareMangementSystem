using DMSClassLibrary;
using DMSClassLibrary.Entities;
using DMSClassLibrary.Interfaces;
using DMSWeb.Helpers;
using DMSWeb.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DMSWeb.Controllers
{
    public class AdminController : HelperController
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ISystemAccountHelper _systemAccountHelper;
        public AdminController(ILogger<AdminController> logger, IConfiguration appConfig, ISystemAccountHelper systemAccountHelper)
        {
            _logger = logger;
            _systemAccountHelper = systemAccountHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(system_accounts account)
        {
            if (_systemAccountHelper.IsAccountAuthenticated(new system_accounts { username = account.username, password = account.password })) return GoToHomePage();
            return GoToLogin("Access Denied!");
        }
    }
}