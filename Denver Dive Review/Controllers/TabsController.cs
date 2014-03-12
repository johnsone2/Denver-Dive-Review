using System.Web.Mvc;
using BarTabService;

namespace Denver_Dive_Review.Controllers
{
    public class TabsController : Controller
    {
        //
        // GET: /Tabs/

        public ActionResult Index()
        {
            var service = new BarTabFileService();
            var allTabs = 
            return View();
        }

    }
}
