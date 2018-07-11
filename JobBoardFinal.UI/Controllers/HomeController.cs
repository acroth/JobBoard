using System.Web.Mvc;

namespace JobBoardFinal.UI.Controllers
{
   
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin,Manager,Employee")]
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
