using Microsoft.Owin;
using Monster.Platform.Infrastructure;
using Monster.Platform.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Monster.Platform.Middlewares
{
    public class MvcMiddleware: OwinMiddleware
    {
        private MvcConfiguration _config;
        public MvcMiddleware(OwinMiddleware next, MvcConfiguration config): base(next)
        {
            _config = config;
        }

        public override async Task Invoke(IOwinContext context)
        {
            var routine = context.Request.Path.Value.Substring(1);
            RoutineInfo routineInfo;
            var isExists = _config.Route.TryGet(routine, out routineInfo);
            if (isExists)
            {
                var executingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                var controller = Activator.CreateInstance(executingAssemblyName, routineInfo.ControllerName).Unwrap();

                var calledAction = controller.GetType().GetMethod(routineInfo.ActionName);
                var result = calledAction.Invoke(controller, null);
                var str = JsonConvert.SerializeObject(result);
                await context.Response.WriteAsync(str);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }

            if (Next != null)
            {
                await Next.Invoke(context);
            }            
        }
    }
}
