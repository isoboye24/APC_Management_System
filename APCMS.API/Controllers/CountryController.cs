using APCMS.API.DTOs.Countries;
using APCMS.API.Utilities;
using APCMS.Application.Features.Countries.Commands.CreateCountry;
using APCMS.Application.Features.Countries.Commands.DeleteCountry;
using APCMS.Application.Features.Countries.Commands.UpdateCountry;
using APCMS.Application.Features.Countries.Queries.GetCountryDetail;
using APCMS.Application.Features.Countries.Queries.GetCountryLists;
using APCMS.Application.Features.Countries.Queries.GetDeletedCountryLists;
using APCMS.Application.Features.Positions.Queries.GetDeletedPositionLists;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryDTO createCountryDTO)
        {
            var command = new CreateCountryCommand
            {
                Name = createCountryDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryListsDTO>>> GetAll([FromQuery] GetCountryListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDetailDTO>> GetById(Guid id)
        {
            var query = new GetCountryDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCountryDTO updateCountryDTO)
        {
            var command = new UpdateCountryCommand
            {
                Id = id,
                Name = updateCountryDTO.Name,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCountryCommand { Id = id });
            return NoContent();
        }

        [HttpGet("deleted")]
        public async Task<ActionResult<List<DeletedCountryListsDTO>>> GetDeleted([FromQuery] GetDeletedCountryListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }
    }
}
