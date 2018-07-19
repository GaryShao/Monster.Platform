using Monster.OldWeb.Handlers;
using Monster.OldWeb.Models;
using System;
using System.Web;

namespace Monster.OldWeb
{
    public class Route : RouteBase
    {
        public IRouteHandler RouteHandler { get; set; }
        public string Url { get; set; }
        public RouteValueDictionary DataTokens { get; set; }
        public RouteValueDictionary Defaults { get; set; }
        public RouteValueDictionary Constraints { get; set; }


        public Route()
        {
            DataTokens = new RouteValueDictionary();
            RouteHandler = new MvcRouteHandler();
        }

        public Route(string url, IRouteHandler routeHandler)
        {
            Url = url;
            RouteHandler = routeHandler;
        }

        public Route(string url, IRouteHandler routeHandler, RouteValueDictionary defaults)
        {
            Url = url;
            RouteHandler = routeHandler;
            Defaults = defaults;
        }

        public Route(string url, IRouteHandler routeHandler, RouteValueDictionary defaults, RouteValueDictionary constraints)
        {
            Url = url;
            RouteHandler = routeHandler;
            Defaults = defaults;
            Constraints = constraints;
        }

        public Route(string url, IRouteHandler routeHandler, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens)
        {
            Url = url;
            RouteHandler = routeHandler;
            Defaults = defaults;
            Constraints = constraints;
            DataTokens = dataTokens;
        }


        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteValueDictionary variables;
            if (Match(httpContext.Request.AppRelativeCurrentExecutionFilePath.Substring(2), out variables))
            {
                var routeData = new RouteData();
                foreach (var item in variables)
                {
                    routeData.Values.Add(item.Key, item.Value);
                }
                foreach (var item in DataTokens)
                {
                    routeData.DataTokens.Add(item.Key, item.Value);
                }
                routeData.RouteHandler = RouteHandler;
                return routeData;
            }
            return null;
        }

        protected bool Match(string requestUrl, out RouteValueDictionary variables)
        {
            variables = new RouteValueDictionary();
            string[] realPath = requestUrl.Split('/');
            string[] definedTemplate = Url.Split('/');
            if (realPath.Length != definedTemplate.Length)
            {
                return false;
            }
            for (int i = 0; i < definedTemplate.Length; i++)
            {
                if (definedTemplate[i].StartsWith("{") && definedTemplate[i].EndsWith("}"))
                {
                    variables.Add(definedTemplate[i].Trim("{}".ToCharArray()), realPath[i]);
                }
                else
                {
                    if (string.Compare(realPath[i], definedTemplate[i], true) != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            throw new NotImplementedException();
        }
    }
}
