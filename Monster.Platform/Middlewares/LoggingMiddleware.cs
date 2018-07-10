using log4net;
using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace Monster.Platform.Middlewares
{
    public class LoggingMiddleware: OwinMiddleware
    {
        private static readonly ILog log = LogManager.GetLogger("FileLogger");
        public LoggingMiddleware(OwinMiddleware next): base(next)
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
                log.Error(ex);
                throw ex;
            }
        }
    }
}
