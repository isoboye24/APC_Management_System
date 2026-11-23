using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetDeletedEmploymentStatusLists
{
    public class GetDeletedEmploymentStatusListsQueryHandler : IRequestHandler<GetDeletedEmploymentStatusListsQuery, PaginatedDTO<DeletedEmploymentStatusListsDTO>>
    {
        private readonly IEmploymentStatusRepository _repository;

        public GetDeletedEmploymentStatusListsQueryHandler(IEmploymentStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedEmploymentStatusListsDTO>> Handle(GetDeletedEmploymentStatusListsQuery request)
        {
            var employmentStatuses = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var employmentStatusList = employmentStatuses.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedEmploymentStatusListsDTO>
            {
                Items = employmentStatusList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
