using DMSClassLibrary;
using DMSClassLibrary.Entities;
using DMSClassLibrary.Interfaces;
using DMSWeb.Helpers;
using DMSWeb.Helpers.Containers;
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
        private readonly ISystemAccountSession _systemAccountSession;
        public AdminController(ILogger<AdminController> logger, IConfiguration appConfig, ISystemAccountHelper systemAccountHelper, ISystemAccountSession systemAccountSession)
        {
            _logger = logger;
            _systemAccountHelper = systemAccountHelper;
            _systemAccountSession = systemAccountSession;
        }

        public IActionResult Index()
        {
            AdminHomeViewData view_data = new AdminHomeViewData();
            if (!_systemAccountHelper.IsUserLogin()) return GoToLogin();

            view_data.account_loggedin = _systemAccountHelper.GetSystemAccountInfoFromSession();
            ViewBag.Username = _systemAccountSession.GetSessionSystemUsername();
            ViewBag.FirstName = _systemAccountSession.GetSessionUserFirstName();
            ViewBag.LastName = _systemAccountSession.GetSessionUserLastName();
            ViewBag.AccessLevelId = _systemAccountSession.GetSessionSystemAccessLevelId();
            return View(view_data);
        }

        public IActionResult Login(string access="")
        {
            if (!string.IsNullOrEmpty(access)) ViewBag.Message = "Access Denied";
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(system_accounts account)
        {
            if (_systemAccountHelper.IsAccountAuthenticated(new system_accounts { username = account.username, password = account.password }))
            {
                return GoToAdminHomePage();
            }

            return GoToLogin("false");
        }
    }
}