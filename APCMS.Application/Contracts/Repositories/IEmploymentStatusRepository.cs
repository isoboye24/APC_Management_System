using APCMS.Application.Features.EmploymentStatuses.Queries.GetDeletedEmploymentStatusLists;
using APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusLists;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface IEmploymentStatusRepository : IRepository<EmploymentStatus>
    {
        Task<bool> Exists(string name, bool isDeleted = false);
        Task<IEnumerable<EmploymentStatus>> GetFiltered(EmploymentStatusFilterDTO filter);

        Task<IEnumerable<EmploymentStatus>> GetDeletedFiltered(DeletedEmploymentStatusFilterDTO filter);
    }
}
