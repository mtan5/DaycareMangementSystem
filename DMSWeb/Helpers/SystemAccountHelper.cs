using DMSClassLibrary.Entities;
using DMSClassLibrary.Interfaces;
using DMSWeb.Helpers.Interfaces;

namespace DMSWeb.Helpers
{
    public class SystemAccountHelper : ISystemAccountHelper
    {
        private readonly ILogger<SystemAccountHelper> _logger;
        private readonly ISystemAccount _systemAccount;
        public SystemAccountHelper(ILogger<SystemAccountHelper> logger, IConfiguration appConfig, ISystemAccount systemAccount)
        {
            _logger = logger;
            _systemAccount = systemAccount;
        }
        public bool IsAccountAuthenticated(system_accounts account)
        {
            try
            {
                system_accounts db_account = _systemAccount.AutehnticateUser(account.username, account.password);
                if (string.IsNullOrEmpty(db_account.username)) return false;
                return true;
            }
            catch (Exception exc)
            {
                _logger.LogError($"SystemAccountHelper > IsAccountAuthenticated(): {exc.ToString()}");
                throw exc.InnerException;
            }
        }
    }
}
