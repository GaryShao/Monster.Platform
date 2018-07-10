using System.Web;

namespace Monster.UnitTest.Expose
{
    public abstract class RouteBase
    {
        public abstract RouteData GetRouteData(HttpContextBase httpContext);
    }
}
