using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Countries.Queries.GetCountryLists
{
    public class GetCountryListsQuery : CountryFilterDTO, IRequest<PaginatedDTO<CountryListsDTO>>
    {
    }
}
