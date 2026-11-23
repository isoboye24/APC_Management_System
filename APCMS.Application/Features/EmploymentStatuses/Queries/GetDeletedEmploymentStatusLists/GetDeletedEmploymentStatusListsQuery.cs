using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetDeletedEmploymentStatusLists
{
    public class GetDeletedEmploymentStatusListsQuery : DeletedEmploymentStatusFilterDTO, IRequest<PaginatedDTO<DeletedEmploymentStatusListsDTO>>
    {
    }
}
