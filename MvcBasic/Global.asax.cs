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
            //WEB�A�v���P�[�V�����N���ݒ�
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //�f�[�^�x�[�X�������ݒ�
            Database.SetInitializer<MvcBasicContext>(new MvcBasicInitializer());

            //�r���[�G���W����Razor�����ɂ���i���s���x�������オ��j
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            //IPhone��p�y�[�W�ɔ�΂�������o�^
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("iPhone")
                {
                    ContextCondition = c =>
                        c.Request.UserAgent.Contains("iPhone")
                });
        }
    }
}
