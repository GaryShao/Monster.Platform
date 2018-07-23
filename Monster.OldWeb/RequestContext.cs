using System;
using System.Web;

namespace Monster.OldWeb
{
    public class RequestContext
    {
        public  RequestContext()
        {

        }

        public RequestContext(HttpContextBase httpContext, RouteData routeData)
        {
            if (HttpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            if (routeData == null)
            {
                throw new ArgumentException("routeData");
            }
            HttpContext = httpContext;
            RouteData = RouteData;
        }

        public virtual HttpContextBase HttpContext { get; set; }
        public virtual RouteData RouteData { get; set; }
    }
}
