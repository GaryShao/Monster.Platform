using Monster.Platform.Attributes;
using Monster.Platform.Infrastructure;
using System.Web.Http;

namespace Monster.Platform.Controllers
{
    [RoutePrefix("api/demo/")]
    public class DemoController: IControllerBase
    {
        [RoutePostfix("greeting"), HttpGet]
        public object Greeting()
        {            
            return "hello world";
        }
    }
}
