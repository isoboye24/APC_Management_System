using APCMS.Application.Features.MaritalStatuses.Queries.GetDeletedMaritalStatusLists;
using APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusLists;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface IMaritalStatusRepository : IRepository<MaritalStatus>
    {
        Task<bool> Exists(string name, bool isDeleted = false);
        Task<IEnumerable<MaritalStatus>> GetFiltered(MaritalStatusFilterDTO filter);

        Task<IEnumerable<MaritalStatus>> GetDeletedFiltered(DeletedMaritalStatusFilterDTO filter);
    }
}
