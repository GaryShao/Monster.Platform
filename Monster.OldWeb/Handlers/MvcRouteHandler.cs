using System;
using System.Web;

namespace Monster.OldWeb.Handlers
{
    public class MvcRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MvcHttpHandler(requestContext);
        }
    }
}
