using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.AttendanceStatuses.GetAttendanceStatusList
{
    public class GetAttendanceStatusListsQuery : AttendanceStatusesFilterDTO, IRequest<PaginatedDTO<AttendanceStatusListsDTO>>
    {
    }
}
