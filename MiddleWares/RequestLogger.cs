using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace CrouseServiceAdvertisement.MiddleWares
{
    public class RequestStartLogger
    {
        private readonly RequestDelegate _next;

        public RequestStartLogger(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (Serilog.Log.Logger != null)
                Serilog.Log.Logger.Information(string.Format("*[reqstId: {0} {1} {2} {3}",
                    httpContext.TraceIdentifier, httpContext.Request.Protocol, httpContext.Request.Method, httpContext.Request.Path));
            return _next(httpContext);
        }
    }


    public class RequestFinishLogger
    {
        private readonly RequestDelegate _next;

        public RequestFinishLogger(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string un = "-";
            string app = "-";
            if (httpContext.User != null)
            {
                if (httpContext.User.Identity != null) un = httpContext.User.Identity.Name;
                if (httpContext.User.Claims != null && httpContext.User.Claims.Any(m => m.Type == "app"))
                    app = httpContext.User.Claims.Where(m => m.Type == "app").First().Value;
            }
            if (Serilog.Log.Logger != null)
                Serilog.Log.Logger.Information(string.Format("requestId: {0} {1} {2} {3} un:{4} app:{5}]*",
                    httpContext.TraceIdentifier, httpContext.Request.Protocol, httpContext.Request.Method, httpContext.Request.Path, un, app));
            return _next(httpContext);
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestLoggerExtensions
    {
        public static IApplicationBuilder UseRequestStartLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestStartLogger>();
        }
        public static IApplicationBuilder UseRequestFinishLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestFinishLogger>();
        }
    }
}
