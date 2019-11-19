using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Nesops.Monitor.Log.Client.Domains;

namespace Nesops.Monitor.Log.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly NesopsLog Log;
        public CustomExceptionMiddleware(RequestDelegate next, NesopsLog _log)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            Log = _log;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    Log.Warning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }
                var result = context.Request.Body;
                return;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
