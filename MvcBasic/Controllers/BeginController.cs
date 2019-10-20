using MvcBasic.DataBase.Model;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class BeginController : Controller
    {
        private MvcBasicContext db = new MvcBasicContext();

        public BeginController()
        {
            db.Database.Log = sql => Debug.Write(sql);
        }

        // GET: Begin
        public ActionResult Index()
        {
            return Content("こんにちは、世界");
        }

        // Get: Show
        public ActionResult Show()
        {
            ViewBag.Message = "こんにちは世界";
            return View();
        }

        // Get: List
        public ActionResult List()
        {
            return View(db.Members.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}