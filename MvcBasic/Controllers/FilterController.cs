using MvcBasic.Controllers.Filter.Authorization;
using MvcBasic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class FilterController : Controller
    {
        // GET: Filter
        public ActionResult Index()
        {
            return View();
        }

        // GET: Filter/Exception
        public ActionResult Exception()
        {
            throw new Exception("意図的に発生された例外");
        }

        // GET: Filter/Exception2
        public ActionResult Exception2()
        {
            throw new ArgumentException("ArgumentException用に用意されたページに飛ばされるはずです。");
        }

        // GET: Filter/Cach
        [OutputCache(Duration = 10)]
        public ActionResult Cach()
        {
            return View(DateTime.Now);
        }

        // GET: Filter/Limit
        [TimeLimite("2014/12/1", "2019/11/11")]
        public ActionResult Limit()
        {
            return Content("有効期間中です");
        }

        // Get: Filter/Login
        [OverrideAuthorization]
        public ActionResult Login()
        {
            return View();
        }

        // Post: Filter/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OverrideAuthorization]
        public ActionResult Login([Bind(Include = "UserName,Password")] UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                Session["User"] = userVM;

                return RedirectToAction("UserInfo");
            }

            return View(userVM);
        }

        //Ge: Filter/UserInfo
        public ActionResult UserInfo()
        {
            var userVM = (Session["User"] as UserViewModel);
            return View(userVM);
        }

        //セレクター関係の実験以下

        [ActionName("andoukun")]
        public ActionResult Abcd()
        {
            return Content("よく来たな");
        }
    }
}