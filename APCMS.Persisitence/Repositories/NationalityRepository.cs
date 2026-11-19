using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Features.Nationalities.Queries.GetDeletedNationalityLists;
using APCMS.Application.Features.Nationalities.Queries.GetNationalityLists;
using APCMS.Domain.Entities;
using APCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence.Repositories
{
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        private readonly APCMSDBContext _db;
        public NationalityRepository(APCMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string name, bool isDeleted = false)
        {
            var exists = await _db.Nationalities.Where(x => x.Name == name && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Nationality>> GetDeletedFiltered(DeletedNationalityFilterDTO filter)
        {
            var query = _db.Nationalities.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Nationality>> GetFiltered(NationalityFilterDTO filter)
        {
            var query = _db.Nationalities.Where(x => !x.IsDeleted);

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
