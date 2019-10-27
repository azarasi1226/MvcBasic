using System;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            string userAgent = Request.Browser.Capabilities[""].ToString();

            ViewBag.userAgent = userAgent;

            return View();
        }

        [ChildActionOnly]
        public ActionResult CurrentTime()
        {
            return PartialView("_CurrentTimePartial", DateTime.Now);
        }
    }
}