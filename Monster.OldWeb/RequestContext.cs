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
            HttpContext = httpContext;
            RouteData = RouteData;
        }

        public virtual HttpContextBase HttpContext { get; set; }
        public virtual RouteData RouteData { get; set; }
    }
}
