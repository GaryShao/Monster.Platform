using System.Collections.Generic;

namespace Monster.OldWeb.Models
{
    public class VirtualPathData
    {
        public VirtualPathData(RouteBase route, string virtualPath)
        {
            Route = route;
            VirtualPath = virtualPath;
        }

        public IDictionary<string, object> DataTokens { get; }
        public RouteBase Route { get; set; }
        public string VirtualPath { get; set; }
    }
}