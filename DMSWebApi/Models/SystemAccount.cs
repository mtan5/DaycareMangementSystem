using DMSClassLibrary.Entities;
using DMSClassLibrary.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace DMSWebApi.Models
{
    public class SystemAccount : ISystemAccount
    {
        private readonly DmsDbContext _dmsdbcontext;
        private readonly ILogger<SystemAccount> _logger;

        public SystemAccount(DmsDbContext dmsdbcontext, ILogger<SystemAccount> logger)
        {
            _dmsdbcontext = dmsdbcontext;
            _logger = logger;
        }

        public bool AddNewSystemAccount(system_accounts new_account_object)
        {
            throw new NotImplementedException();
        }

        public system_accounts AutehnticateUser(string username = "", string password = "")
        {
            system_accounts system_account = new system_accounts();
            try
            {
                system_account = _dmsdbcontext.system_accounts.Where(
                    x => x.username == username 
                    && x.password.ToLower() == MD5Hash(password).ToLower() 
                    && x.status == true).FirstOrDefault();
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);                
            }
            return system_account;
        }

        public system_accounts GetSystemAccountInfo(int account_id)
        {
            system_accounts system_account = new system_accounts();
            try
            {
                system_account = _dmsdbcontext.system_accounts.Where(x => x.id == account_id).FirstOrDefault();
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
            }
            return system_account;
        }

        public bool UpdateSystemAccount(system_accounts new_account_object)
        {
            throw new NotImplementedException();
        }

        private string MD5Hash(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
