using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    /// <summary>
    /// 状態管理
    /// </summary>
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Index()
        {
            return View();
        }

        /*----------クッキー----------*/
        // GET: State/Cookie
        public ActionResult Cookie()
        {
            if(Request.Cookies["email"] != null)
            {
                ViewBag.Email = Request.Cookies["email"].Value;
            }

            return View();
        }

        // POST: State/Cookie
        [HttpPost]
        public ActionResult Cookie(string email)
        {
            Response.AppendCookie(new HttpCookie("email")
            {
                Value    = email,
                Expires  = DateTime.Now.AddDays(7),
                HttpOnly = true
            });

            return RedirectToAction("Cookie");
        }

        /*----------セッション----------*/
        // GET: State/SessionRecord
        //Sessionって名前だと元からあるプロパティと競合するので仕方なく...
        public ActionResult SessionRecord()
        {
            ViewBag.Email = Session["email"];

            return View();
        }

        // Post: State/SessionRecord
        [HttpPost]
        public ActionResult SessionRecord(string email)
        {
            //セッションemailを保存
            Session["email"] = email;

            return RedirectToAction("SessionRecord");
        }

        /*----------一時データ(TempData)----------*/
        // GET: State/TempData
        public ActionResult TempDataRecord()
        {
            TempData["tempMessage"] = "Redirectで保存される一時データです";

            return RedirectToAction("Index");
        }
    }
}