using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisTweet.Controllers
{
    public class TestController: Controller
    {
        //[Route("api/user")]
        [HttpGet("api/user")]
        public IActionResult Get()
        {
            return Ok(new { nombre = "Samuel" });
        }
    }
}
