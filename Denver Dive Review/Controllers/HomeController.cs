using System.Linq;
using System.Web.Mvc;
using BarTabService;

namespace Denver_Dive_Review.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var tabController = new BarTabFileService();
            var allTabs = tabController.GetAll();

            var tabTotal = allTabs.Aggregate(0d, (runningTotal, tab) => runningTotal + tab.TabAmount);

            return View(tabTotal);
        }

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

        public ActionResult Team()
        {
            ViewBag.Message = "Our dope-ass team.";

            return View();
        }
    }
}
