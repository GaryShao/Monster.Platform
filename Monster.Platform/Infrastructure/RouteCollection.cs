using Monster.Platform.Attributes;
using Monster.Platform.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Monster.Platform.Infrastructure
{
    public class RouteCollection
    {
        private IDictionary<string, RoutineInfo> _routine;

        public RouteCollection()
        {
            _routine = new Dictionary<string, RoutineInfo>();
            Initial();
        }

        private void Initial()
        {
            var controllerInterface = typeof(IControllerBase);
            var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(t => controllerInterface.IsAssignableFrom(t) && t.IsClass);

            foreach (var controller in controllers)
            {                
                var prefix = controller.GetCustomAttribute<RoutePrefixAttribute>().Prefix;
                var actions = controller.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
                foreach (var action in actions)
                {
                    var postfix = action.GetCustomAttribute<RoutePostfixAttribute>().Postfix;
                    _routine.Add(prefix + postfix, new RoutineInfo {
                        ControllerName = controller.FullName,
                        ActionName = action.Name,
                        HttpMethod = action.GetCustomAttributes().
                                        Where(attr => typeof(IActionHttpMethodProvider).IsAssignableFrom(attr.GetType())).
                                        FirstOrDefault().GetType().Name.Replace("Attribute", "")
                    });
                }
            }
        }

        public bool TryGet(string routine, out RoutineInfo routineInfo)
        {
            var isExists = _routine.ContainsKey(routine);
            if (isExists)
            {
                routineInfo = _routine[routine];
                return true;
            }
            routineInfo = null;
            return false;
        }
    }
}
