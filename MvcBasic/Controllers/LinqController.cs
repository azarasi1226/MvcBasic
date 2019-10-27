using MvcBasic.DataBase.Model;
using System.Linq;
using System.Web.Mvc;
using System;
using System.Diagnostics;

namespace MvcBasic.Controllers
{
    public class LinqController : Controller
    {
        private readonly MvcBasicContext db = new MvcBasicContext();
        private int accessCount; 

        public LinqController()
        {
            // ログ出力
            db.Database.Log = sql => Debug.Write(sql);
            Console.WriteLine("Membersインスタンスが作成されました");
        }

        // GET: Linq
        public ActionResult Index()
        {
            return View();
        }

        // GET: Linq/Search
        public ActionResult Search(string keyword, bool? released)
        {
            var query = db.Articles.AsQueryable();

            // [キーワード]欄が空でない場合、その値で部分検索をかける
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(a => a.Title.Contains(keyword));
            }

            // [公開済み]チェックがついてる場合、公開済みの記事だけ絞り込む
            if (released.HasValue && released.Value)
            {
                query = query.Where(a => a.Released);
            }

            return View(query.ToList());
        }

        //GET: Linq/Orderby
        public ActionResult Orderby()
        {
            this.accessCount++;
            var articles = db.Articles
                             .OrderBy(a => a.Published)
                             .ThenByDescending(a => a.Title);

            ViewBag.Count = this.accessCount;
            return View(articles.ToList());
        }

        //GET: Linq/Distinct()
        public ActionResult Distinct()
        {
            var comments = db.Comments
                             .OrderBy(c => c.Name)
                             .Select(c => c.Name)
                             .Distinct();

            return View(comments.ToList());
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