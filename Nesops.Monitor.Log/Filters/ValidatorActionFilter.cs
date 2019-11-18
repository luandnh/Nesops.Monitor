using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nesops.Monitor.Log.Client.Domains;
using NesopsService.Service.Models.ResponseModels;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace Nesops.Monitor.Log.Filters
{
    public class ValidatorActionFilter : IActionFilter
    {
        NesopsLog Log = new NesopsLog();
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (filterContext.Exception != null)
            {
                filterContext.Result = new ObjectResult(new BaseResponseModel<object> { message = filterContext.Exception.Message, code = (int)HttpStatusCode.InternalServerError })
                {
                    StatusCode = 500,
                };
                if (filterContext.HttpContext.Request.Method == "POST")
                {
                    var json = JsonConvert.SerializeObject(filterContext.HttpContext.Request.Body);
                    Log.Error(filterContext.Exception);
                }
                filterContext.ExceptionHandled = true;
            }

        }
    }
}
