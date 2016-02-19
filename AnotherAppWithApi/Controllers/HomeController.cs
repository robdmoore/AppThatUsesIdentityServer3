using System.Security.Claims;
using System.Web.Mvc;

namespace AnotherAppWithApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AuthenticatedPage()
        {
            return View((User as ClaimsPrincipal).Claims);
        }
    }
}
