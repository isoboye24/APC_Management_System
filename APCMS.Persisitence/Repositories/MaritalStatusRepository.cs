using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Features.MaritalStatuses.Queries.GetDeletedMaritalStatusLists;
using APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusLists;
using APCMS.Domain.Entities;
using APCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence.Repositories
{
    public class MaritalStatusRepository : Repository<MaritalStatus>, IMaritalStatusRepository
    {
        private readonly APCMSDBContext _db;
        public MaritalStatusRepository(APCMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string name, bool isDeleted = false)
        {
            var exists = await _db.MaritalStatuses.Where(x => x.Name == name && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<MaritalStatus>> GetDeletedFiltered(DeletedMaritalStatusFilterDTO filter)
        {
            var query = _db.MaritalStatuses.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaritalStatus>> GetFiltered(MaritalStatusFilterDTO filter)
        {
            var query = _db.MaritalStatuses.Where(x => !x.IsDeleted);

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
