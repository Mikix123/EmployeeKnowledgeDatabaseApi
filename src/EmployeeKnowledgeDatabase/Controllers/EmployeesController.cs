using EmployeeKnowledgeDatabase.Dtos;
using EmployeeKnowledgeDatabase.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Infrastructure;
using EmployeeKnowledgeDatabase.Messages.Commands;

namespace EmployeeKnowledgeDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator, User")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<EmployeeDto>))]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllEmployees()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(EmployeeWithDetailsDto))]
        public async Task<ActionResult<EmployeeWithDetailsDto>> GetById(long id)
        {
            return Ok(await _mediator.Send(new GetEmployeeById(id)));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<EmployeeDto>))]
        public async Task<ActionResult<EmployeeWithDetailsDto>> Add(AddEmployee command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(long id, UpdateEmployee command)
        {
            return Ok(await _mediator.Send(command.Bind(x => x.Id, id)));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(long id)
        {
            return Ok(await _mediator.Send(new DeleteEmployee(id)));
        }
    }
}