using DMSClassLibrary;
using DMSClassLibrary.Entities;
using DMSClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DMSWeb.Models
{
    public class SystemAccount : ISystemAccount
    {
        private readonly ILogger<SystemAccount> _logger;
        private IConfiguration _appConfig { get; }
        private string _webApibaseUrl;
        private string _ApiKey;
        private string _ApiHeader;
        public SystemAccount(ILogger<SystemAccount> logger, IConfiguration appConfig)
        {
            _logger = logger;
            _appConfig = appConfig;
            _webApibaseUrl = _appConfig["AppSettings:WebApiBaseUrl"];
            _ApiKey = _appConfig["AppSettings:ApiKey"];
            _ApiHeader = _appConfig["AppSettings:ApiHeaderKey"];
        }
        public system_accounts AutehnticateUser(string username = "", string password = "")
        {
            try
            {
                WebApiParameter api_param = new WebApiParameter
                {
                    ApiHeader = _ApiHeader,
                    ApiKey = _ApiKey,
                    url = $"{_webApibaseUrl}/system_account/post_authenticateuser",
                    ObjectString = JsonConvert.SerializeObject(new system_accounts { username = username, password = password, first_name="", last_name="" })
                };
                var jsonList = WebApiLibrary.PostMethodRetrieveData(api_param);
                var account = JsonConvert.DeserializeObject<system_accounts>(jsonList);
                return account;
            }
            catch (Exception exc)
            {
                _logger.LogError($"SystemAccountController > AutehnticateUser(): {exc.ToString()}");
                throw exc.InnerException;
            }

        }

        public system_accounts GetSystemAccountInfo(int account_id)
        {
            throw new NotImplementedException();
        }

        public bool AddNewSystemAccount(system_accounts new_account_object)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSystemAccount(system_accounts new_account_object)
        {
            throw new NotImplementedException();
        }
    }
}
