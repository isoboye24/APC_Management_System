using APCMS.API.DTOs.EmploymentStatuses;
using APCMS.Application.Features.EmploymentStatuses.Commands.CreateEmploymentStatus;
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
    }
}
