using APCMS.API.DTOs.EmploymentStatuses;
using APCMS.API.Utilities;
using APCMS.Application.Features.EmploymentStatuses.Commands.CreateEmploymentStatus;
using APCMS.Application.Features.EmploymentStatuses.Commands.DeleteEmploymentStatus;
using APCMS.Application.Features.EmploymentStatuses.Commands.PermanentlyDeleteEmploymentStatus;
using APCMS.Application.Features.EmploymentStatuses.Commands.RestoreEmploymentStatus;
using APCMS.Application.Features.EmploymentStatuses.Commands.UpdateEmploymentStatus;
using APCMS.Application.Features.EmploymentStatuses.Queries.GetDeletedEmploymentStatusLists;
using APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusDetail;
using APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusLists;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/employment-statuses")]
    public class EmploymentStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmploymentStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmploymentStatusDTO createEmploymentStatusDTO)
        {
            var command = new CreateEmploymentStatusCommand
            {
                Name = createEmploymentStatusDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<EmploymentStatusListsDTO>>> GetAll([FromQuery] GetEmploymentStatusListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentStatusDetailDTO>> GetById(Guid id)
        {
            var query = new GetEmploymentStatusDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmploymentStatusDTO updateEmploymentStatusDTO)
        {
            var command = new UpdateEmploymentStatusCommand
            {
                Id = id,
                Name = updateEmploymentStatusDTO.Name,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEmploymentStatusCommand { Id = id });
            return NoContent();
        }

        [HttpGet("deleted")]
        public async Task<ActionResult<List<DeletedEmploymentStatusListsDTO>>> GetDeleted([FromQuery] GetDeletedEmploymentStatusListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            await _mediator.Send(new RestoreEmploymentStatusCommand
            {
                Id = id
            });

            return NoContent();
        }

        [HttpDelete("{id}/permanent")]
        public async Task<IActionResult> DeletePermanently(Guid id)
        {
            await _mediator.Send(new PermanentlyDeleteEmploymentStatusCommand { Id = id });
            return NoContent();
        }
    }
}
