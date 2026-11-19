using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Countries.Queries.GetDeletedCountryLists
{
    public class GetDeletedCountryListsQuery : DeletedCountriesFilterDTO, IRequest<PaginatedDTO<DeletedCountryListsDTO>>
    {
    }
}
