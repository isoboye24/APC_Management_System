using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Features.Positions.Queries.GetDeletedPostionLists;
using APCMS.Application.Features.Positions.Queries.GetPostionLists;
using APCMS.Domain.Entities;
using APCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly APCMSDBContext _db;
        public PositionRepository(APCMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string name, bool isDeleted = false)
        {
            var exists = await _db.Positions.Where(x => x.Name == name && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Position>> GetDeletedFiltered(DeletedPositionsFilterDTO filter)
        {
            var query = _db.Positions.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetFiltered(PositionFilterDTO filter)
        {
            var query = _db.Positions.Where(x => !x.IsDeleted);

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
