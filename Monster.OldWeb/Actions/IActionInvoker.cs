using Monster.OldWeb.Models;

namespace Monster.OldWeb.Actions
{
    public interface IActionInvoker
    {
        void InvokeAction(ControllerContext controllerContext, string actionName);
    }
}