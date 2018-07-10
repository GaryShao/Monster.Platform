using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace Monster.Platform.Middlewares
{
    public class GlobalExceptionMiddleware: OwinMiddleware
    {
        public GlobalExceptionMiddleware(OwinMiddleware next) : base(next)
        {
            
        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                return;
            }
        }
    }
}
