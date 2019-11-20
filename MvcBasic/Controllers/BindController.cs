using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBasic.DataBase.Model;
using MvcBasic.ViewModels;

namespace MvcBasic.Controllers
{
    public class BindController : Controller
    {
        private readonly MvcBasicContext db = new MvcBasicContext();

        public BindController()
        {
            // ログ出力
            db.Database.Log = sql => Debug.Write(sql);
        }

        // GET: Bind
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bind/CreateList
        public ActionResult CreateList(List<MemberViewModel> list)
        {
            try
            {
                // リストから順番にMemberViewModelオブジェクトを取り出す。
                foreach (var memberVm in list)
                {
                    //Nameプロパティが空のところで処理を中断
                    if (string.IsNullOrEmpty(memberVm.Name))
                    {
                        break;
                    }

                    db.Members.Add(memberVm.ToMember());
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Members");
            }
            catch
            {
                //はじめから入力させなおす
                return View();
            }
        }

        // 以下ファイルアップロード系処理
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase data)
        {
            //アップロードできるファイル拡張子を定義
            var extensions = new[] { ".jpg", ".png", ".gif" };

            // ファイルが送られてこなかった場合
            if(data == null)
            {
                ViewBag.Message = "ファイルを指定してください。";
                return View();
            }

            // 対応外の拡張子の場合
            if (!extensions.Contains(Path.GetExtension(data.FileName)))
            {
                ViewBag.Message = "対応外の拡張子です。";
                return View();
            }

            //　保存
            //保存を確認。Debug、Releaseで保存される先が違うので注意。
            //同じ名前で登録すると上書きされる。
            data.SaveAs(Path.Combine(
                Server.MapPath("~/App_Data/Photos"),
                Path.GetFileName(data.FileName)    
            ));
            ViewBag.Message = "保存しました。";

            return View();
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