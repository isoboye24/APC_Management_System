using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.PaymentStatuses.Queries.GetDeletedPaymentStatusLists
{
    public class GetDeletedPaymentStatusListsQueryHandler : IRequestHandler<GetDeletedPaymentStatusListsQuery, PaginatedDTO<DeletedPaymentStatusListDTO>>
    {
        private readonly IPaymentStatusRepository _repository;

        public GetDeletedPaymentStatusListsQueryHandler(IPaymentStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedPaymentStatusListDTO>> Handle(GetDeletedPaymentStatusListsQuery request)
        {
            var paymentStatuses = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var paymentStatusList = paymentStatuses.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedPaymentStatusListDTO>
            {
                Items = paymentStatusList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
