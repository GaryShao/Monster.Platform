using Monster.OldWeb.Actions;
using Monster.OldWeb.Models;

namespace Monster.OldWeb.Controllers
{
    public abstract class ControllerBase : IController
    {
        protected IActionInvoker ActionInvoker { get; set; }

        public ControllerBase()
        {
            ActionInvoker = new ControllerActionInvoker();
        }

        public void Execute(RequestContext requestContext)
        {
            var context = new ControllerContext
            {
                RequestContext = requestContext,
                Controller = this,                
            };
            var actionName = requestContext.RouteData.Action;
            ActionInvoker.InvokeAction(context, actionName);
        }
    }
}