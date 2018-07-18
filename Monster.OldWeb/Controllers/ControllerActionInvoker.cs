using Monster.OldWeb.Actions;
using Monster.OldWeb.Binders;
using Monster.OldWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Monster.OldWeb.Controllers
{
    public class ControllerActionInvoker : IActionInvoker
    {
        public ControllerActionInvoker()
        {
            ModelBinder = new DefaultModelBinder();
        }

        public IModelBinder ModelBinder { get; }

        public void InvokeAction(ControllerContext controllerContext, string actionName)
        {
            var controller = controllerContext.Controller;
            var matchedAction = controller.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(m => string.Compare(actionName, m.Name, true) == 0);

            var parameters = new List<object>();
            foreach (ParameterInfo parameter in matchedAction.GetParameters())
            {
                parameters.Add(ModelBinder.BindModel(controllerContext, parameter.Name, parameter.ParameterType));
            }

            var executor = new ActionExecutor(matchedAction);
            var actionResult = (ActionResult)executor.Execute(controllerContext.Controller, parameters.ToArray());
            actionResult.ExecuteResult(controllerContext);
        }
    }
}