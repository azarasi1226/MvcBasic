using MvcBasic.DataBase.Entity;
using MvcBasic.DataBase.Model;
using MvcBasic.ViewModels;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class MembersController : Controller
    {
        private readonly MvcBasicContext db = new MvcBasicContext();

        public MembersController()
        {
            // ログ出力
            db.Database.Log = sql => Debug.Write(sql);
            Console.WriteLine("Membersインスタンスが作成されました");
        }

        // GET: Members
        [OverrideAuthorization]
        public ActionResult Index()
        {
            return View(db.Members.ToList().Select(m => new MemberViewModel(m)));
        }

        // GET: Members/Details/{id}
        public ActionResult Details(int? id)
        {
            // 不正なURL
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // 要求されたデータが存在しなかった
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            return View(new MemberViewModel(member));
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,EmailConfirmed,Birth,Married,Memo")] MemberViewModel memberVM)
        {
            // モデル検証(true=正常)
            if (ModelState.IsValid)
            {
                db.Members.Add(memberVM.ToMember());
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // 再入力
            return View(memberVM);
        }

        // GET: Members/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            return View(new MemberViewModel(member));
        }

        // POST: Members/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,EmailConfirmed,Birth,Married,Memo")] MemberViewModel memberVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberVM.ToMember()).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(memberVM);
        }

        // GET: Members/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            return View(new MemberViewModel(member));
        }

        // POST: Members/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();

            return RedirectToAction("Index");
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