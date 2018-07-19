using Monster.OldWeb.Handlers;
using System.Collections.Generic;

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
