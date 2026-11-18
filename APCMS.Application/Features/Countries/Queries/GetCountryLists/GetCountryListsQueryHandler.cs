using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Countries.Queries.GetCountryLists
{
    public class GetCountryListsQueryHandler : IRequestHandler<GetCountryListsQuery, PaginatedDTO<CountryListsDTO>>
    {
        private readonly ICountryRepository _repository;
        public GetCountryListsQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<CountryListsDTO>> Handle(GetCountryListsQuery request)
        {
            var countries = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var countryList = countries.Select(c => c.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<CountryListsDTO>
            {
                Items = countryList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
