using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Bootcamp_Odev_2.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public ExceptionMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext,IConfiguration config)
        {
            try
            {
                var currentVersion = new Version(config.GetValue<string>("AppVersion"));
                if(httpContext.Request.Headers.TryGetValue("app-version",out var version)&& Version.TryParse(version,out var requestVersion)&& requestVersion.CompareTo(currentVersion)<=0
                    || httpContext.Request.Path=="/login"||httpContext.Request.Path== "/register")
                { 
                await _next(httpContext);
            }
                else
                {
                    //aksi durumda 401 kodu dönecektir
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("Status401Unauthorized");
                }
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            
        }

       

        private async Task HandleExceptionAsync(HttpContext httpContext,Exception exception)
        {
           
            httpContext.Response.StatusCode = 401;
            await httpContext.Response.WriteAsync($"Internal Server Error.Detail:  {exception.Message}   ");
        }
    }


    
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
