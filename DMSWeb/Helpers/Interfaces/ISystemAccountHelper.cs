using DMSClassLibrary.Entities;

namespace DMSWeb.Helpers.Interfaces
{
    public interface ISystemAccountHelper
    {
        bool IsAccountAuthenticated(system_accounts account);
    }
}
