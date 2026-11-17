using APCMS.API.Utilities;
using APCMS.Application.Features.AttendanceStatuses.GetAttendanceStatusList;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/attendance-statuses")]
    public class AttendanceStatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AttendanceStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttendanceStatusListsDTO>>> GetAll([FromQuery] GetAttendanceStatusListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }
    }
}
