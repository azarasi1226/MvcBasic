using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers.Filter.Authorization
{
    /// <summary>
    /// ログインしているか判定する承認フィルター
    /// </summary>
    public class LoginCheckAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("コンテントがnullです");
            }

            var user = filterContext.HttpContext.Session["User"];

            if(user == null)
            {
                filterContext.Result = new ContentResult
                {
                    Content = "セッションが切れました、ログインし直してください"
                };
            }
        }
    }
}