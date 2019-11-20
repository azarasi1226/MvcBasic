using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class ResultController : Controller
    {
        //GET: Result
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Download(string fileName)
        {
            var filePath = Server.MapPath($"~/App_Data/Photos/{fileName}");

            if (System.IO.File.Exists(filePath))
            {
                return File(filePath, "image/jpeg", "gazou.jpg");
            }

            return HttpNotFound("画像がないよ");
        }
    }
}