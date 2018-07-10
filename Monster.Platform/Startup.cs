using Monster.Platform.MiddlewareExtensions;
using Owin;

namespace Monster.Platform
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            app.UseGlobalExceptionMiddleware();
            app.UseLoggingMiddleware();
            app.UseMvcMiddleware();
        }
    }
}
