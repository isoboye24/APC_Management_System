using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Features.EmploymentStatuses.Queries.GetDeletedEmploymentStatusLists;
using APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusLists;
using APCMS.Domain.Entities;
using APCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence.Repositories
{
    public class EmploymentStatusRepository : Repository<EmploymentStatus>, IEmploymentStatusRepository
    {        
        private readonly APCMSDBContext _db;

        public EmploymentStatusRepository(APCMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string name, bool isDeleted = false)
        {
            var exists = await _db.EmploymentStatuses.Where(x => x.Name == name && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<EmploymentStatus>> GetDeletedFiltered(DeletedEmploymentStatusFilterDTO filter)
        {
            var query = _db.EmploymentStatuses.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<EmploymentStatus>> GetFiltered(EmploymentStatusFilterDTO filter)
        {
            var query = _db.EmploymentStatuses.Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
