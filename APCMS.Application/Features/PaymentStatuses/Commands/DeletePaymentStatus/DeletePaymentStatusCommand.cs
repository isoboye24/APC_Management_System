using APCMS.Application.Utilities;

namespace APCMS.Application.Features.PaymentStatuses.Commands.DeletePaymentStatus
{
    public class DeletePaymentStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
