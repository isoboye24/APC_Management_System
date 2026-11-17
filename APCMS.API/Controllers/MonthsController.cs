using APCMS.API.Utilities;
using APCMS.Application.Features.Months.GetMonthsList;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/months")]
    public class MonthsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MonthsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MonthListsDTO>>> GetAll([FromQuery] GetMonthListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }
    }
}
