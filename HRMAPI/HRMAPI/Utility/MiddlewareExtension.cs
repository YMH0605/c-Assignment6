using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HRMAPI.Utility
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareExtension
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger _logger;
        public MiddlewareExtension(RequestDelegate next)
        {
            _next = next;
            //_logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
            await HandleExceptionAsync(httpContext, ex);
            }
            

        }

        public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/text";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync("Status Code = " + httpContext.Response.StatusCode + "Messgae = " + exception.Message) ;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensionExtensions
    {
        public static IApplicationBuilder UseMiddlewareExtension(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<MiddlewareExtension>();
        }
    }
}

