using APCMS.Application.Utilities;

namespace APCMS.Application.Features.PaymentStatuses.Commands.UpdatePaymentStatus
{
    public class UpdatePaymentStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
