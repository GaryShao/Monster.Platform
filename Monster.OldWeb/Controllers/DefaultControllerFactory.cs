using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;

namespace Monster.OldWeb.Controllers
{
    public class DefaultControllerFactory : IControllerFactory
    {
        private static List<Type> controllerTypes = new List<Type>();

        static DefaultControllerFactory()
        {
            foreach (Assembly assembly in BuildManager.GetReferencedAssemblies())
            {
                var controllers = assembly.GetTypes().Where(t => typeof(IController).IsAssignableFrom(t));
                foreach (Type controllerType in controllers)
                {
                    controllerTypes.Add(controllerType);
                }
            }
        }

        public IController Create(RequestContext requestContext, string controllerName)
        {
            var typeName = controllerName + "Controller";
            var matchedController = controllerTypes.FirstOrDefault(c => string.Compare(typeName, c.Name, true) == 0);
            if (matchedController == null)
            {
                return null;
            }
            return (IController)Activator.CreateInstance(matchedController);
        }
    }
}