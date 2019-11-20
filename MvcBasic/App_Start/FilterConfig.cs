using System;
using System.Web.Mvc;

namespace MvcBasic
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //基本的な例外設定
            filters.Add(new HandleErrorAttribute());

            //ArgumentException例外設定
            filters.Add(new HandleErrorAttribute
            {
                //実行順番(デフォルト値-1,大きいほうが優先)
                Order = 2,
                //キャッチする例外の型設定
                ExceptionType = typeof(ArgumentException),
                //Viewの指定
                View = "ErrorSpare"
            });
        }
    }
}
