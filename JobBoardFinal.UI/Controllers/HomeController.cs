using System.Web.Mvc;

namespace JobBoardFinal.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Manager")]
    [Authorize(Roles = "Employee")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
