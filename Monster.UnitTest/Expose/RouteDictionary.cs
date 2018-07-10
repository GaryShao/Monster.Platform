using System.Collections.Generic;
using System.Web;

namespace Monster.UnitTest.Expose
{
    public class RouteDictionary: Dictionary<string, RouteBase>
    {
        public RouteData GetRouteData(HttpContextBase httpContext)
        {
            foreach (var route in Values)
            {
                RouteData routeData = route.GetRouteData(httpContext);
                if (null != routeData)
                {
                    return routeData;
                }
            }
            return null;
        }
    }
}
