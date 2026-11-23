using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.MaritalStatuses.Queries.GetDeletedMaritalStatusLists
{
    public class GetDeletedMaritalStatusListsQuery : DeletedMaritalStatusFilterDTO, IRequest<PaginatedDTO<DeletedMaritalStatusListsDTO>>
    {
    }
}
