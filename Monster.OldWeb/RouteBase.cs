using Monster.OldWeb.Models;
using System.Collections.Generic;
using System.Web;

namespace Monster.OldWeb
{
    public abstract class RouteBase
    {
        public abstract RouteData GetRouteData(HttpContextBase httpContext);

        public abstract VirtualPathData GetVirtualPath(RequestContext requestContext, IDictionary<string, object> values);

        public bool RouteExistingFiles { get; set; }
    }
}
