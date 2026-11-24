using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusDetail
{
    public class GetPaymentStatusDetailQueryHandler : IRequestHandler<GetPaymentStatusDetailQuery, PaymentStatusDetailDTO>
    {
        private readonly IPaymentStatusRepository _repository;

        public GetPaymentStatusDetailQueryHandler(IPaymentStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaymentStatusDetailDTO> Handle(GetPaymentStatusDetailQuery request)
        {
            var paymentStatus = await _repository.GetById(request.Id);

            if (paymentStatus is null)
            {
                throw new NotFoundException("Payment status is not found");
            }

            return paymentStatus.ToDTO();
        }
    }
}
