using System.Web;

namespace Monster.OldWeb.Handlers
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }
}
