using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;
using NLite;
using NLite.Reflection;

namespace NLite.Web
{
    public class PageHandlerFactory : System.Web.UI.PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
        {
            return HttpHandlerFactory.GetHandler(virtualPath);
        }
    }
  

}
