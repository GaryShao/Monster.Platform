using System.Collections.Generic;

namespace Monster.UnitTest.Expose
{
    public class RouteData
    {
        public IDictionary<string, object> Values { get; private set; }
        public IDictionary<string, object> DataTokens { get; private set; }
        public IRouteHandler RouteHandler { get; set; }
        public RouteBase Route { get; set; }

        public RouteData()
        {
            Values = new Dictionary<string, object>();
            DataTokens = new Dictionary<string, object>();
            DataTokens.Add("namespaces", new List<string>());
        }

        public string Controller
        {
            get
            {
                object controllerName = string.Empty;
                this.Values.TryGetValue("controller", out controllerName);
                return controllerName.ToString();
            }
        }

        public string Action
        {
            get
            {
                object actionName = string.Empty;
                this.Values.TryGetValue("action", out actionName);
                return actionName.ToString();
            }
        }
    }

    
}
