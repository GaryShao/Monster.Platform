using Monster.OldWeb.Handlers;
using System.Collections.Generic;
using System.Web;

namespace Monster.OldWeb
{
    public class Route : RouteBase
    {
        public IRouteHandler RouteHandler { get; set; }        
        public string Url { get; set; }
        public IDictionary<string, object> DataTokens { get; set; }

        public Route()
        {
            DataTokens = new Dictionary<string, object>();
            RouteHandler = new MvcRouteHandler();
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            IDictionary<string, object> variables;
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

        protected bool Match(string requestUrl, out IDictionary<string, object> variables)
        {
            variables = new Dictionary<string, object>();
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
    }
}
