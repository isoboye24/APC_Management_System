using APCMS.API.DTOs.MaritalStatuses;
using APCMS.API.Utilities;
using APCMS.Application.Features.MaritalStatuses.Commands.CreateMaritalStatus;
using APCMS.Application.Features.MaritalStatuses.Commands.DeleteMaritalStatus;
using APCMS.Application.Features.MaritalStatuses.Commands.UpdateMaritalStatus;
using APCMS.Application.Features.MaritalStatuses.Queries.GetDeletedMaritalStatusLists;
using APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusDetail;
using APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusLists;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/marital-statuses")]
    public class MaritalStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaritalStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMaritalStatusDTO createMaritalStatusDTO)
        {
            var command = new CreateMaritalStatusCommand
            {
                Name = createMaritalStatusDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<MaritalStatusListsDTO>>> GetAll([FromQuery] GetMaritalStatusListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaritalStatusDetailDTO>> GetById(Guid id)
        {
            var query = new GetMaritalStatusDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateMaritalStatusDTO updateMaritalStatusDTO)
        {
            var command = new UpdateMaritalStatusCommand
            {
                Id = id,
                Name = updateMaritalStatusDTO.Name,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteMaritalStatusCommand { Id = id });
            return NoContent();
        }

        [HttpGet("deleted")]
        public async Task<ActionResult<List<DeletedMaritalStatusListsDTO>>> GetDeleted([FromQuery] GetDeletedMaritalStatusListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }
    }
}
