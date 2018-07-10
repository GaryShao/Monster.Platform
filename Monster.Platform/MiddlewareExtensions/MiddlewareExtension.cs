using Monster.Platform.Infrastructure;
using Monster.Platform.Middlewares;
using Owin;

namespace Monster.Platform.MiddlewareExtensions
{
    public static class MiddlewareExtension
    {
        public static void UseMvcMiddleware(this IAppBuilder builder)
        {
            var config = new MvcConfiguration();
            builder.Use<MvcMiddleware>(config);
        }

        public static void UseGlobalExceptionMiddleware(this IAppBuilder builder)
        {
            builder.Use<GlobalExceptionMiddleware>();
        }

        public static void UseLoggingMiddleware(this IAppBuilder builder)
        {
            builder.Use<LoggingMiddleware>();
        }
    }
}
