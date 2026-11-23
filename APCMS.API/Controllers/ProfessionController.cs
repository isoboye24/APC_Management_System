using APCMS.API.DTOs.Professions;
using APCMS.API.Utilities;
using APCMS.Application.Features.Professions.Commands.CreateProfession;
using APCMS.Application.Features.Professions.Commands.UpdateProfession;
using APCMS.Application.Features.Professions.Queries.GetProfessionDetail;
using APCMS.Application.Features.Professions.Queries.GetProfessionLists;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/professions")]
    public class ProfessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProfessionDTO createProfessionDTO)
        {
            var command = new CreateProfessionCommand
            {
                Name = createProfessionDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<List<ProfessionListsDTO>>> GetAll([FromQuery] GetProfessionListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessionDetailDTO>> GetById(Guid id)
        {
            var query = new GetProfessionDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProfessionDTO updateProfessionDTO)
        {
            var command = new UpdateProfessionCommand
            {
                Id = id,
                Name = updateProfessionDTO.Name,
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
