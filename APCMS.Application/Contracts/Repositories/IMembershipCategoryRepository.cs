using APCMS.Application.Features.MembershipCategories.Queries.GetDeletedMembershipCategoryLists;
using APCMS.Application.Features.MembershipCategories.Queries.GetMembershipCategoryLists;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface IMembershipCategoryRepository : IRepository<MembershipCategory>
    {
        Task<bool> Exists(string name, bool isDeleted = false);
        Task<IEnumerable<MembershipCategory>> GetFiltered(MembershipCategoryFilterDTO filter);

        Task<IEnumerable<MembershipCategory>> GetDeletedFiltered(DeletedMembershipCategoryFilterDTO filter);
    }
}
