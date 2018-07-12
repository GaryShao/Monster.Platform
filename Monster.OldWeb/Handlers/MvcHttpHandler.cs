using System;
using System.Web;
using Monster.OldWeb.Controllers;

namespace Monster.OldWeb.Handlers
{
    public class MvcHttpHandler : IHttpHandler
    {
        public MvcHttpHandler(RequestContext requestContext)
        {
            RequestContext = requestContext;
        }

        public bool IsReusable => false;
        public RequestContext RequestContext { get; }

        public void ProcessRequest(HttpContext context)
        {
            string controllerName = RequestContext.RouteData.Controller;
            IControllerFactory controllerFactory =
                ControllerBuilder.Current.GetControllerFactory();
            IController controller = controllerFactory.Create(RequestContext, controllerName);
            controller.Execute(RequestContext);
        }
    }
}