using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using Nesops.Monitor.Log.Client.Domains;
using NesopsService.Service.Models.ResponseModels;

namespace Nesops.Monitor.Log.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, NesopsLog Log)
        {
            var bodyStr = "";
            if (context.Request.Method != "GET")
            {
                var req = context.Request;
                req.EnableBuffering();
                using (StreamReader reader
                          = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await reader.ReadToEndAsync();
                }
                req.Body.Position = 0;
            }
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                if (IsApiCall(context.Request))
                {
                    IActionResult result;
                    result = new ObjectResult(new BaseResponseModel<object> { message = ex.Message, code = (int)HttpStatusCode.InternalServerError })
                    {
                        StatusCode = 500,
                    };
                    var method = context.Request.Method;
                    if (method == "POST" || method == "PUT")
                    {
                        Log.Error(ex, bodyStr);
                    }
                    // now we have a IActionResult, let's return it
                    RouteData routeData = context.GetRouteData();
                    ActionDescriptor actionDescriptor = new ActionDescriptor();
                    ActionContext actionContext = new ActionContext(context, routeData, actionDescriptor);
                    await result.ExecuteResultAsync(actionContext);
                    return;
                }
                throw;
            }

        }
        private bool IsApiCall(HttpRequest request)
        {
            bool isJson = request.GetTypedHeaders().Accept.Contains(
                new MediaTypeHeaderValue("application/json"));
            if (isJson)
                return true;
            if (request.Path.Value.StartsWith("/api/"))
                return true;
            return false;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
