using System;
using System.Web;
using System.Web.UI;

namespace Monster.OldWeb.Pages
{
    public class Page : TemplateControl, IHttpHandler
    {
        public RouteData RouteData { get; }
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}