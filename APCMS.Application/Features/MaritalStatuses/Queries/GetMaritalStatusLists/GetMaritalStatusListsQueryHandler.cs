using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusLists
{
    public class GetMaritalStatusListsQueryHandler : IRequestHandler<GetMaritalStatusListsQuery, PaginatedDTO<MaritalStatusListsDTO>>
    {
        private readonly IMaritalStatusRepository _repository;

        public GetMaritalStatusListsQueryHandler(IMaritalStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<MaritalStatusListsDTO>> Handle(GetMaritalStatusListsQuery request)
        {
            var maritalStatuses = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var maritalStatusList = maritalStatuses.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<MaritalStatusListsDTO>
            {
                Items = maritalStatusList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
