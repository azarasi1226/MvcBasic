using MvcBasic.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class LinqController : Controller
    {
        private MvcBasicContext db = new MvcBasicContext();

        // GET: Linq
        public ActionResult Index()
        {
            return View();
        }


        // GET: Search
        public ActionResult Search(string keyword, bool? released)
        {
            var query = db.Articles.AsQueryable();

            // [キーワード]欄がから出ない場合、その値で部分検索をかける
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
    }
}