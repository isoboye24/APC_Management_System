using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusLists
{
    public class GetEmploymentStatusListsQuery : EmploymentStatusFilterDTO, IRequest<PaginatedDTO<EmploymentStatusListsDTO>>
    {
    }
}
