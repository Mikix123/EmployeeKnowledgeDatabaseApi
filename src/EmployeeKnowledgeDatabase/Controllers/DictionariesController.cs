using EmployeeKnowledgeDatabase.Dtos;
using EmployeeKnowledgeDatabase.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Infrastructure;
using EmployeeKnowledgeDatabase.Messages.Commands;
using MediatR;

namespace EmployeeKnowledgeDatabase.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator, User")]
    public class DictionariesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DictionariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<DictionaryDto>))]
        public async Task<ActionResult<IEnumerable<IdValueDto<long, string>>>> GetAll(
            [FromQuery(Name = "dictionary")] IEnumerable<DictionaryTypes> dictionaries)
        {
            return Ok();
        }

        [HttpGet("{dictionary}/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IdValueDto<long, string>))]
        public async Task<ActionResult<IdValueDto<long, string>>> GetDictionaryItemById(DictionaryTypes dictionary, long id)
        {
            return Ok();
        }

        [HttpPost("{dictionary}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> AddDictionaryItem(DictionaryTypes dictionary, AddDictionaryItem command)
        {
            await _mediator.Send(command.Bind(x => x.DictionaryType, dictionary));
            return Ok();
        }

        [HttpPut("{dictionary}/{id}")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateDictionaryItem(DictionaryTypes dictionary,
            long id, UpdateDictionaryItem command)
        {
            await _mediator.Send(command.Bind(x => x.DictionaryType, dictionary)
                .Bind(x => x.Id, id));

            return Ok();
        }

        [HttpDelete("{dictionary}/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteDictionaryItem(DictionaryTypes dictionary,
            long id)
        {
            await _mediator.Send(new DeleteDictionaryItem(dictionary, id));

            return NoContent();
        }
    }
}