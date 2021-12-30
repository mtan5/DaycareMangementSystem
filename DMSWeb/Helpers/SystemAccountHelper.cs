using DMSClassLibrary.Entities;
using DMSClassLibrary.Interfaces;
using DMSWeb.Helpers.Interfaces;

namespace DMSWeb.Helpers
{
    public class SystemAccountHelper : ISystemAccountHelper
    {
        private readonly ILogger<SystemAccountHelper> _logger;
        private readonly ISystemAccount _systemAccount;
        private readonly ISystemAccountSession _systemAccountSession;
        public SystemAccountHelper(ILogger<SystemAccountHelper> logger, IConfiguration appConfig, ISystemAccount systemAccount, ISystemAccountSession systemAccountSession)
        {
            _logger = logger;
            _systemAccount = systemAccount;
            _systemAccountSession = systemAccountSession;
        }

        public system_accounts GetSystemAccountInfoFromSession()
        {
            try
            {
                system_accounts db_account = new system_accounts {
                    id = _systemAccountSession.GetSessionSystemAccountId(),
                    username = _systemAccountSession.GetSessionSystemUsername(),
                    first_name = _systemAccountSession.GetSessionUserFirstName(),
                    last_name = _systemAccountSession.GetSessionUserLastName(),
                    access_level_id = _systemAccountSession.GetSessionSystemAccessLevelId()
                    };
                return db_account;
            }
            catch (Exception exc)
            {
                _logger.LogError($"SystemAccountHelper > GetSystemAccountInfoFromSession(): {exc.ToString()}");
                throw exc.InnerException;
            }
        }

        public bool IsAccountAuthenticated(system_accounts account)
        {
            try
            {
                system_accounts db_account = _systemAccount.AutehnticateUser(account.username, account.password);
                if (db_account == null) return false;
                SetSystemAccountSession(db_account);
                return true;
            }
            catch (Exception exc)
            {
                _logger.LogError($"SystemAccountHelper > IsAccountAuthenticated(): {exc.ToString()}");
                throw exc.InnerException;
            }
        }

        public bool IsUserLogin()
        {
            if (string.IsNullOrEmpty(_systemAccountSession.GetSessionSystemUsername())) return false;
            return true;
        }

        private void SetSystemAccountSession(system_accounts account)
        {
            _systemAccountSession.SetSessionSystemAccountId(account.id);
            _systemAccountSession.SetSessionSystemUsername(account.username);
            _systemAccountSession.SetSessionUserFirstName(account.first_name);
            _systemAccountSession.SetSessionUserLastName(account.last_name);
            _systemAccountSession.SetSessionSystemAccessLevelId(account.access_level_id);
        }
    }
}
