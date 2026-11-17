using APCMS.Application.Features.AttendanceStatuses.GetAttendanceStatusList;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface IAttendanceStatusRepository
    {
        Task<IEnumerable<AttendanceStatus>> GetFiltered(AttendanceStatusesFilterDTO filter);
        Task<AttendanceStatus?> GetById(Guid id);
    }
}
