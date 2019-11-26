using MvcBasic.DataBase.Entity;
using MvcBasic.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcBasic.Controllers
{
    public class AjaxController : ApiController
    {
        public string GetMember()
        {
            using (var dbc = new MvcBasicContext())
            {
                
            }

            return "aaa";
        }
    }
}
