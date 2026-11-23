using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusLists
{
    public class GetMaritalStatusListsQuery : MaritalStatusFilterDTO, IRequest<PaginatedDTO<MaritalStatusListsDTO>>
    {
    }
}
