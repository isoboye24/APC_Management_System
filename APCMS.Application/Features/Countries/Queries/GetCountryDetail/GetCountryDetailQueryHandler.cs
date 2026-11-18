using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Countries.Queries.GetCountryDetail
{
    public class GetCountryDetailQueryHandler : IRequestHandler<GetCountryDetailQuery, CountryDetailDTO>
    {
        private readonly ICountryRepository _repository;
        public GetCountryDetailQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CountryDetailDTO> Handle(GetCountryDetailQuery request)
        {
            var country = await _repository.GetById(request.Id);

            if (country is null)
            {
                throw new NotFoundException("Country is not found");
            }

            return country.ToDTO();
        }
    }
}
