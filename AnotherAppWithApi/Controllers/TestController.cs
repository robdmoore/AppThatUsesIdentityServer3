using System.Security.Claims;
using System.Web.Http;

namespace AnotherAppWithApi.Controllers
{
    [Route("test")]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            return Json(new
            {
                message = "OK computer",
                client = caller.FindFirst("client_id").Value
            });
        }
    }
}