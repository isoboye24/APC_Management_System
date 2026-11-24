using APCMS.API.DTOs.PaymentStatuses;
using APCMS.API.Utilities;
using APCMS.Application.Features.PaymentStatuses.Commands.CreatePaymentStatus;
using APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusDetail;
using APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusLists;
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

        [HttpGet]
        public async Task<ActionResult<List<PaymentStatusListsDTO>>> GetAll([FromQuery] GetPaymentStatusListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentStatusDetailDTO>> GetById(Guid id)
        {
            var query = new GetPaymentStatusDetailQuery { Id = id };
            return await _mediator.Send(query);
        }
    }
}
