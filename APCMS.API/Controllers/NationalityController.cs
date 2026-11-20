using APCMS.API.DTOs.Nationalities;
using APCMS.API.Utilities;
using APCMS.Application.Features.Nationalities.Commands.CreateNationality;
using APCMS.Application.Features.Nationalities.Commands.DeleteNationality;
using APCMS.Application.Features.Nationalities.Commands.RestoreNationality;
using APCMS.Application.Features.Nationalities.Commands.UpdateNationality;
using APCMS.Application.Features.Nationalities.Queries.GetDeletedNationalityLists;
using APCMS.Application.Features.Nationalities.Queries.GetNationalityDetail;
using APCMS.Application.Features.Nationalities.Queries.GetNationalityLists;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/nationalities")]
    public class NationalityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NationalityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNationalityDTO createNationalityDTO)
        {
            var command = new CreateNationalityCommand
            {
                Name = createNationalityDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<NationalityListsDTO>>> GetAll([FromQuery] GetNationalityListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NationalityDetailDTO>> GetById(Guid id)
        {
            var query = new GetNationalityDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateNationalityDTO updateNationalityDTO)
        {
            var command = new UpdateNationalityCommand
            {
                Id = id,
                Name = updateNationalityDTO.Name,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteNationalityCommand { Id = id });
            return NoContent();
        }

        [HttpGet("deleted")]
        public async Task<ActionResult<List<DeletedNationalityListsDTO>>> GetDeleted([FromQuery] GetDeletedNationalityListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            await _mediator.Send(new RestoreNationalityCommand
            {
                Id = id
            });

            return NoContent();
        }
    }
}
