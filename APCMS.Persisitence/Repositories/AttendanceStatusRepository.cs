using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Features.AttendanceStatuses.GetAttendanceStatusList;
using APCMS.Domain.Entities;
using APCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence.Repositories
{
    public class AttendanceStatusRepository : IAttendanceStatusRepository
    {
        private readonly APCMSDBContext _db;
        public AttendanceStatusRepository(APCMSDBContext db)
        {
            _db = db;
        }

        public async Task<AttendanceStatus?> GetById(Guid id)
        {
            return await _db.AttendanceStatuses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AttendanceStatus>> GetFiltered(AttendanceStatusesFilterDTO filter)
        {
            var query = _db.AttendanceStatuses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(x =>
                    x.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
