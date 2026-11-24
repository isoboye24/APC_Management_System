using APCMS.Application.Utilities;

namespace APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusDetail
{
    public class GetPaymentStatusDetailQuery : IRequest<PaymentStatusDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
