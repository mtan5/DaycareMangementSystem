using DMSClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSClassLibrary.Interfaces
{
    public interface ISystemAccount
    {
        system_accounts AutehnticateUser(string username = "", string password = "");
        system_accounts GetSystemAccountInfo(int account_id);
        bool AddNewSystemAccount(system_accounts new_account_object);
        bool UpdateSystemAccount(system_accounts new_account_object);
        
    }
}
