using APCMS.API.DTOs.MaritalStatuses;
using APCMS.API.Utilities;
using APCMS.Application.Features.MaritalStatuses.Commands.CreateMaritalStatus;
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
    }
}
