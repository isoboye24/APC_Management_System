using APCMS.Application.Features.Nationalities.Queries.GetDeletedNationalityLists;
using APCMS.Application.Features.Nationalities.Queries.GetNationalityLists;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface INationalityRepository : IRepository<Nationality>
    {
        Task<bool> Exists(string name, bool isDeleted = false);
        Task<IEnumerable<Nationality>> GetFiltered(NationalityFilterDTO filter);
        Task<IEnumerable<Nationality>> GetDeletedFiltered(DeletedNationalityFilterDTO filter);
    }
}
