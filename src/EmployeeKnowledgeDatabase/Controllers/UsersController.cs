using System.Net;
using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Infrastructure.Authentication;
using EmployeeKnowledgeDatabase.Messages.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeKnowledgeDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(JsonWebToken))]
        [AllowAnonymous]
        public async Task<ActionResult<JsonWebToken>> LogIn(Login command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}