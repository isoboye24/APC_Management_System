using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Features.Months.GetMonthsList;
using APCMS.Domain.Entities;
using APCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence.Repositories
{
    public class MonthRepository : IMonthRepository
    {
        private readonly APCMSDBContext _db;
        public MonthRepository(APCMSDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Month>> GetFiltered(
            MonthsFilterDTO filter)
        {
            var query = _db.Months.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(x =>
                    x.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Id)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<Month?> GetById(int id)
        {
            return await _db.Months
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetTotalAmountOfRecords()
        {
            return await _db.Months.CountAsync();
        }
    }
}

