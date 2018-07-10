using System;
using System.Web;

namespace Monster.UnitTest.Expose
{
    public class Global: HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(
                "default", 
                new Route { Url = "{controller}/{action}" }
            );
        }
    }
}
