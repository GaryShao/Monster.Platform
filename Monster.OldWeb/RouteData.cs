using Monster.OldWeb.Handlers;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Monster.OldWeb
{
    public class RouteData
    {
        public RouteValueDictionary Values { get; private set; }
        public RouteValueDictionary DataTokens { get; private set; }
        public IRouteHandler RouteHandler { get; set; }
        public RouteBase Route { get; set; }

        public RouteData()
        {            
            Values = new RouteValueDictionary();
            DataTokens = new RouteValueDictionary();
            DataTokens.Add("namespaces", new List<string>());
        }

        public RouteData(RouteBase route, IRouteHandler routeHandler)
        {
            Route = route;
            RouteHandler = routeHandler;
        }

        public string GetRequiredString(string valueName)
        {
            var obj = default(object);
            if (Values.TryGetValue(valueName, out obj))
            {
                var text = obj as string;
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
            }
            throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, "RouteData_RequiredValue", valueName));
        }

        public string Controller
        {
            get
            {
                object controllerName = string.Empty;
                Values.TryGetValue("controller", out controllerName);
                return controllerName.ToString();
            }
        }

        public string Action
        {
            get
            {
                object actionName = string.Empty;
                Values.TryGetValue("action", out actionName);
                return actionName.ToString();
            }
        }
    }    
}
