using APCMS.Application.Utilities;

namespace APCMS.Application.Features.PaymentStatuses.Commands.CreatePaymentStatus
{
    public class CreatePaymentStatusCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
