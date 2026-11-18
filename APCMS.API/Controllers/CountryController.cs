using APCMS.API.DTOs.Countries;
using APCMS.API.Utilities;
using APCMS.Application.Features.Countries.Commands.CreateCountry;
using APCMS.Application.Features.Countries.Queries.GetCountryLists;
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

    }
}
