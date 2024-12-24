using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInfosController : ControllerBase
    {
        protected IMediator _mediator;
        public PersonInfosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
        {
            GetPersonInfoQuery queryFilter = new GetPersonInfoQuery()
            {
                Id = id
            };
            var result = await _mediator.Send(queryFilter, cancellationToken);
            return Ok(result);
        }

        [HttpGet("getRange/{name}/{family}/{startDate}/{endDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetRange(string name, string family, DateTimeOffset startDate, DateTimeOffset endDate, CancellationToken cancellationToken)
        {
            GetRangePersonInfoQuery queryFilter = new GetRangePersonInfoQuery()
            {
                Name = name,
                Family = family,
                StartDate = startDate,
                EndDate = endDate,
            };
            var result = await _mediator.Send(queryFilter, cancellationToken);
            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Add([FromBody] AddPersonInfoModel model, CancellationToken cancellationToken)
        {
            var command = model.ToCommand();

            var newId = await _mediator.Send(command, cancellationToken);

            return Ok(newId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(long id, [FromBody] UpdatePersonInfoModel model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var command = model.ToCommand();

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            DeletePersonInfoCommand command = new DeletePersonInfoCommand { Id = id };

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

    }
}
