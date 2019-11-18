using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nesops.Monitor.Log.Client.Domains;
using NesopsService.Service.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nesops.Monitor.Log.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly NesopsLog Log;
        public CustomExceptionFilter(NesopsLog _log)
        {
            Log = _log;
        }
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new BaseResponseModel<object> { message = context.Exception.Message, code = (int)HttpStatusCode.InternalServerError })
            {
                StatusCode = 500,
            };
            if (context.HttpContext.Request.Method == "POST")
            {
                Log.Error(context.Exception);
            }
            Log.Error(context.Exception);
            context.ExceptionHandled = true;
        }
    }
}
