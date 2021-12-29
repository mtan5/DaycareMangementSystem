using Microsoft.AspNetCore.Mvc;

namespace DMSWebApi.Controllers
{
    [Route("dms_web_api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Pebbles DMS Web Api";
        }
    }
}
