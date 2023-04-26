using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(VaryByParam ="*",Duration =30,Location =System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Hello()
        {
            string greeting = "Hello to all";
            ViewBag.Message = greeting;
            //ViewData["Message"] = greeting;
            //TempData["Message"] = greeting;
            return View();
        }
    }
}