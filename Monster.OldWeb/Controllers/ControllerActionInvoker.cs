using Monster.OldWeb.Actions;
using Monster.OldWeb.Models;
using System.Linq;
using System.Reflection;

namespace Monster.OldWeb.Controllers
{
    public class ControllerActionInvoker : IActionInvoker
    {
        public ControllerActionInvoker()
        {
            //ModelBinder = new DefaultModelBinder();
        }

        //public IModelBinder ModelBinder { get; }

        public void InvokeAction(ControllerContext controllerContext, string actionName)
        {
            var controller = controllerContext.Controller;
            var matchedAction = controller.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(m => string.Compare(actionName, m.Name, true) == 0);

            matchedAction.Invoke(controller, null);
        }
    }
}