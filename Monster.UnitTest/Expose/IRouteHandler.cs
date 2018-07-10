using System.Web;

namespace Monster.UnitTest.Expose
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }
}
