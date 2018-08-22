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
                controllerTypes.AddRange(assembly.GetTypes().
                    Where(type => typeof(IController).IsAssignableFrom(type)));
            }
        }

        public IController Create(RequestContext requestContext, string controllerName)
        {
            var controllerType = GetControllerType(requestContext.RouteData, controllerName);
            if (controllerType == null)
            {
                return null;
            }
            return (IController)Activator.CreateInstance(controllerType);
        }

        private static bool IsNamespaceMatch(string requestedNamespace, string targetNamespace)
        {
            if (!requestedNamespace.EndsWith(".*", StringComparison.OrdinalIgnoreCase))
            {
                return string.Equals(requestedNamespace, targetNamespace, StringComparison.OrdinalIgnoreCase);
            }
            requestedNamespace = requestedNamespace.Substring(0, requestedNamespace.Length - ".*".Length);
            if (!targetNamespace.StartsWith(requestedNamespace, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return ((requestedNamespace.Length == targetNamespace.Length) || (targetNamespace[requestedNamespace.Length] == '.'));
        }

        private Type GetControllerType(IEnumerable<string> namespaces, Type[] controllerTypes)
        {
            var types = (from type in controllerTypes
                         where namespaces.Any(ns => IsNamespaceMatch(ns, type.Namespace))
                         select type).ToArray();
            switch (types.Length)
            {
                case 0: return null;
                case 1: return types[0];
                default: throw new InvalidOperationException("Multiple matched controllers found");
            }
        }

        protected virtual Type GetControllerType(RouteData routeData, string controllerName)
        {
            var types = controllerTypes.Where(type => string.Compare(controllerName + "Controller", type.Name, true) == 0).ToArray();
            if (types.Length == 0)
            {
                return null;
            }
            var namespaces = routeData.DataTokens["Namespaces"] as IEnumerable<string>;
            namespaces = namespaces ?? new string[0];
            var controllerType = GetControllerType(namespaces, types);
            if (controllerType != null)
            {
                return controllerType;
            }

            var useNamespaceFallback = true;
            if (routeData.DataTokens["UseNamespaceFallback"] != null)
            {
                useNamespaceFallback = (bool)(routeData.DataTokens["UseNamespaceFallback"]);
            }
            if (!useNamespaceFallback)
            {
                return null;                
            }

            controllerType = GetControllerType(ControllerBuilder.Current.DefaultNamespaces, types);

            if (controllerType != null)
            {
                return controllerType;
            }
            if (types.Length == 1)
            {
                return types[0];
            }
            throw new InvalidOperationException("Multiple matched controllers found");
        }
    }
}