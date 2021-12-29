using DMSClassLibrary.Entities;
using DMSClassLibrary.Interfaces;

namespace DMSWebApi.Models
{
    public class ApiKeyHandler : IAPIHandler
    {
        private readonly DmsDbContext _dmsdbcontext;

        public ApiKeyHandler(DmsDbContext dmsdbcontext)
        {
            _dmsdbcontext = dmsdbcontext;
        }
        public dms_api_key GetApi(string ApiHeaderValue)
        {
            return _dmsdbcontext.dms_api_key.FirstOrDefault(x => x.id.ToString() == ApiHeaderValue);
        }
    }
}
