using APCMS.Application.Features.Professions.Queries.GetDeletedProfessionLists;
using APCMS.Application.Features.Professions.Queries.GetProfessionLists;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface IProfessionRepository : IRepository<Profession>
    {
        Task<bool> Exists(string name, bool isDeleted = false);
        Task<IEnumerable<Profession>> GetFiltered(ProfessionFilterDTO filter);

        Task<IEnumerable<Profession>> GetDeletedFiltered(Features.Professions.Queries.GetDeletedProfessionLists.DeletedProfessionsFilterDTO filter);
    }
}
