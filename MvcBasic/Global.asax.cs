using MvcBasic.DataBase.Model;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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

            //�r���[�G���W����Razor������
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
