using DMSClassLibrary.Entities;
using DMSClassLibrary.Interfaces;
using DMSWebApi.ApiFilter;
using Microsoft.AspNetCore.Mvc;

namespace DMSWebApi.Controllers
{
    //[ApiController, Route("system_account"), ServiceFilter(typeof(APIKeyHandler))]
    [Route("system_account")]
    [ApiController]
    public class SystemAccountController : ControllerBase
    {
        private ISystemAccount _systemAccount;
        private readonly ILogger<SystemAccountController> _logger;

        public SystemAccountController(ISystemAccount systemAccount, ILogger<SystemAccountController> logger )
        {
            _systemAccount = systemAccount;
            _logger = logger;  
            
        }

        [HttpPost("post_authenticateuser")]
        public system_accounts Post_AuthenticateUser(system_accounts account)
        {
            try
            {
                system_accounts system_account = new system_accounts();
                system_account = _systemAccount.AutehnticateUser(account.username, account.password);
                return system_account;
            }
            catch (Exception exc)
            {
                _logger.LogError($"SystemAccountControllerApi > Post_AuthenticateUser(): {exc.ToString()}");
                return null;
            }
        }

        [HttpGet("sample")]
        public ActionResult<string> Sample()
        {
            return "Here heere";
        }
    }
}