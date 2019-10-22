using MvcBasic.DataBase.Model;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace MvcBasic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //WEBアプリケーション起動設定
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //データベース初期化設定
            Database.SetInitializer<MvcBasicContext>(new MvcBasicInitializer());

            //ビューエンジンをRazorだけにする（実行速度が少し上がる）
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            //IPhone専用ページに飛ばす処理を登録
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("iPhone")
                {
                    ContextCondition = c =>
                        c.Request.UserAgent.Contains("iPhone")
                });
        }
    }
}
