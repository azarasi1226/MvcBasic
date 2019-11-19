using MvcBasic.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    /// <summary>
    /// アクションリザルトクラスの派生クラスの種類を使い分ける事によって、
    /// どのような結果がクライアントに戻るのかチェック
    /// </summary>
    public class ActionResultController : Controller
    {
        private readonly MvcBasicContext db = new MvcBasicContext();

        // GET: ActionResult
        public ActionResult Index()
        {
            return View();
        }

        //Get: ActionResult/ViewResult
        public ActionResult ViewResult()
        {

            return View(new { Name = "aaaa"});
        }

        //Get: ActionResult/Tsv
        public ActionResult Tsv()
        {
            var members = db.Members.ToList();
            var tsv     = new StringBuilder();

            members.ForEach(m =>
                tsv.Append(
                    String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n",
                        m.Id,
                        m.Name,
                        m.Email,
                        m.Birth.ToString("d"),
                        m.Married,
                        m.Memo.Replace("\r\n", "")
                    )));

            //Response.AddHeader("Content-Disposition", "attachment;filename=tsv.txt");
            return Content(tsv.ToString(), 
                "text/html"
                );

        }
    }
}