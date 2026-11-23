using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.MaritalStatuses.Queries.GetDeletedMaritalStatusLists
{
    public class GetDeletedMaritalStatusListsQueryHandler : IRequestHandler<GetDeletedMaritalStatusListsQuery, PaginatedDTO<DeletedMaritalStatusListsDTO>>
    {
        private readonly IMaritalStatusRepository _repository;
        public GetDeletedMaritalStatusListsQueryHandler(IMaritalStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedMaritalStatusListsDTO>> Handle(GetDeletedMaritalStatusListsQuery request)
        {
            var maritalStatuses = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var maritalStatusList = maritalStatuses.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedMaritalStatusListsDTO>
            {
                Items = maritalStatusList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
