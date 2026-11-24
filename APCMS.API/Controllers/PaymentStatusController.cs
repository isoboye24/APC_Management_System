using APCMS.API.DTOs.PaymentStatuses;
using APCMS.Application.Features.PaymentStatuses.Commands.CreatePaymentStatus;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/payment-statuses")]
    public class PaymentStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentStatusDTO createPaymentStatusDTO)
        {
            var command = new CreatePaymentStatusCommand
            {
                Name = createPaymentStatusDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }

    }
}
