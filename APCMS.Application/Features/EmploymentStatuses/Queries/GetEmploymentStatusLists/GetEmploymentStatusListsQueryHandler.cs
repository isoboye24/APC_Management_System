using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusLists
{
    public class GetEmploymentStatusListsQueryHandler : IRequestHandler<GetEmploymentStatusListsQuery, PaginatedDTO<EmploymentStatusListsDTO>>
    {
        private readonly IEmploymentStatusRepository _repository;
        public GetEmploymentStatusListsQueryHandler(IEmploymentStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<EmploymentStatusListsDTO>> Handle(GetEmploymentStatusListsQuery request)
        {
            var employmentStatuses = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var employmentStatusList = employmentStatuses.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<EmploymentStatusListsDTO>
            {
                Items = employmentStatusList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
