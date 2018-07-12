namespace Monster.OldWeb.Controllers
{
    public interface IControllerFactory
    {
        IController Create(RequestContext requestContext, string controllerName);
    }
}
