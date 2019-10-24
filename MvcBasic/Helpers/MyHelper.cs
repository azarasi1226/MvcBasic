using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Helpers
{
    public class MyHelper
    {
        public static IHtmlString Mailto(string address, string linktext)
        {
            address = HttpUtility.HtmlAttributeEncode(address);
            linktext = HttpUtility.HtmlAttributeEncode(linktext);

            var tag = $@"<a href=""mailto:{address}"">{linktext}</a>";

            return MvcHtmlString.Create(tag);
        }
    }
}