using APCMS.API.DTOs.PaymentStatuses;
using APCMS.API.Utilities;
using APCMS.Application.Features.PaymentStatuses.Commands.CreatePaymentStatus;
using APCMS.Application.Features.PaymentStatuses.Commands.DeletePaymentStatus;
using APCMS.Application.Features.PaymentStatuses.Commands.PermanentlyDeletePaymentStatus;
using APCMS.Application.Features.PaymentStatuses.Commands.RestorePaymentStatus;
using APCMS.Application.Features.PaymentStatuses.Commands.UpdatePaymentStatus;
using APCMS.Application.Features.PaymentStatuses.Queries.GetDeletedPaymentStatusLists;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePaymentStatusDTO updatePaymentStatusDTO)
        {
            var command = new UpdatePaymentStatusCommand
            {
                Id = id,
                Name = updatePaymentStatusDTO.Name,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletePaymentStatusCommand { Id = id });
            return NoContent();
        }

        [HttpGet("deleted")]
        public async Task<ActionResult<List<DeletedPaymentStatusListDTO>>> GetDeleted([FromQuery] GetDeletedPaymentStatusListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            await _mediator.Send(new RestorePaymentStatusCommand
            {
                Id = id
            });

            return NoContent();
        }

        [HttpDelete("{id}/permanent")]
        public async Task<IActionResult> DeletePermanently(Guid id)
        {
            await _mediator.Send(new PermanentlyDeletePaymentStatusCommand { Id = id });
            return NoContent();
        }
    }
}
