using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Countries.Queries.GetCountryDetail
{
    public class GetCountryDetailQuery : IRequest<CountryDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
