using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Features.MembershipCategories.Queries.GetDeletedMembershipCategoryLists;
using APCMS.Application.Features.MembershipCategories.Queries.GetMembershipCategoryLists;
using APCMS.Domain.Entities;
using APCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence.Repositories
{
    public class MembershipCategoryRepository : Repository<MembershipCategory>, IMembershipCategoryRepository
    {
        private readonly APCMSDBContext _db;
        public MembershipCategoryRepository(APCMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string name, bool isDeleted = false)
        {
            var exists = await _db.MembershipCategories.Where(x => x.Name == name && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<MembershipCategory>> GetDeletedFiltered(DeletedMembershipCategoryFilterDTO filter)
        {
            var query = _db.MembershipCategories.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<MembershipCategory>> GetFiltered(MembershipCategoryFilterDTO filter)
        {
            var query = _db.MembershipCategories.Where(x => !x.IsDeleted);

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
