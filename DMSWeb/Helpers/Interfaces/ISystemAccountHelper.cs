using DMSClassLibrary.Entities;

namespace DMSWeb.Helpers.Interfaces
{
    public interface ISystemAccountHelper
    {
        bool IsUserLogin();
        bool IsAccountAuthenticated(system_accounts account);
        system_accounts GetSystemAccountInfoFromSession();
    }
}
