using APCMS.API.DTOs.Nationalities;
using APCMS.API.Utilities;
using APCMS.Application.Features.Nationalities.Commands.CreateNationality;
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
    }
}
