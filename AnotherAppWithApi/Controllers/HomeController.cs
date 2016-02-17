using System.Web.Mvc;

namespace AnotherAppWithApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
