using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusLists
{
    public class GetPaymentStatusListsQueryHandler : IRequestHandler<GetPaymentStatusListsQuery, PaginatedDTO<PaymentStatusListsDTO>>
    {
        private readonly IPaymentStatusRepository _repository;

        public GetPaymentStatusListsQueryHandler(IPaymentStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<PaymentStatusListsDTO>> Handle(GetPaymentStatusListsQuery request)
        {
            var paymentStatuses = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var paymentStatusList = paymentStatuses.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<PaymentStatusListsDTO>
            {
                Items = paymentStatusList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
