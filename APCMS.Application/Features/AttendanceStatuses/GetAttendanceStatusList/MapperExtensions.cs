using APCMS.Domain.Entities;

namespace APCMS.Application.Features.AttendanceStatuses.GetAttendanceStatusList
{
    public static class MapperExtensions
    {
        internal static AttendanceStatusListsDTO ToDTO(this AttendanceStatus attendanceStatus)
        {
            return new AttendanceStatusListsDTO
            {
                Id = attendanceStatus.Id,
                Name = attendanceStatus.Name
            };
        }
    }
}
