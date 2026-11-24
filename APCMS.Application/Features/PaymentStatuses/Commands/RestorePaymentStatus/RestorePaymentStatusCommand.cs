using APCMS.Application.Utilities;

namespace APCMS.Application.Features.PaymentStatuses.Commands.RestorePaymentStatus
{
    public class RestorePaymentStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
