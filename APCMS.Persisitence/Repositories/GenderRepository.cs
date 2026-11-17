using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Features.Genders.GetGenderList;
using APCMS.Domain.Entities;
using APCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly APCMSDBContext _db;
        public GenderRepository(APCMSDBContext db)
        {
            _db = db;
        }

        public async Task<Gender?> GetById(Guid id)
        {
            return await _db.Genders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Gender>> GetFiltered(GendersFilterDTO filter)
        {
            var query = _db.Genders.AsQueryable();

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
