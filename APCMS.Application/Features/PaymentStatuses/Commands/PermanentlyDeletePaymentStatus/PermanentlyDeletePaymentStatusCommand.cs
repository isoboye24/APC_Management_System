using APCMS.Application.Utilities;

namespace APCMS.Application.Features.PaymentStatuses.Commands.PermanentlyDeletePaymentStatus
{
    public class PermanentlyDeletePaymentStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
