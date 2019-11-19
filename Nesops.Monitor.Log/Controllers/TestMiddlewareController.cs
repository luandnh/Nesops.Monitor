using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nesops.Monitor.Log.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestMiddlewareController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create()
        {
            int a = 1, b=0,c;
            c = a / b;
            return Ok();
        }
    }
}