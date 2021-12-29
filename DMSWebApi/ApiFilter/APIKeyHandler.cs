using DMSClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DMSWebApi.ApiFilter
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class APIKeyHandler : Attribute, IAsyncActionFilter
    {
        private IAPIHandler _apiRepo;

        public APIKeyHandler(IAPIHandler apiRepo)
        {
            _apiRepo = apiRepo;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("DmsApiKey", out var ApiHeaderValue))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (_apiRepo.GetApi(ApiHeaderValue) == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            await next();
        }
    }
}
