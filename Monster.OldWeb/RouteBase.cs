using Monster.OldWeb.Models;
using System.Collections.Generic;
using System.Web;

namespace Monster.OldWeb
{
    public abstract class RouteBase
    {
        public abstract RouteData GetRouteData(HttpContextBase httpContext);

        public abstract VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values);

        public bool RouteExistingFiles { get; set; }
    }
}
