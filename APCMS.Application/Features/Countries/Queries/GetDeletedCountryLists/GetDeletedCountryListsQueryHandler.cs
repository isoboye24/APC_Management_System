using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Countries.Queries.GetDeletedCountryLists
{
    public class GetDeletedCountryListsQueryHandler : IRequestHandler<GetDeletedCountryListsQuery, PaginatedDTO<DeletedCountryListsDTO>>
    {
        private readonly ICountryRepository _repository;
        public GetDeletedCountryListsQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedCountryListsDTO>> Handle(GetDeletedCountryListsQuery request)
        {
            var country = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var countryList = country.Select(c => c.ToDTO()).ToList();
            var paginatedResult = new PaginatedDTO<DeletedCountryListsDTO>
            {
                Items = countryList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
