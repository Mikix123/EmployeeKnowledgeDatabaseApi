using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeKnowledgeDatabase.Controllers
{

    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok("Service is working");
        }

    }
}
