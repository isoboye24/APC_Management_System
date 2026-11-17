using APCMS.Application.Features.Genders.GetGenderList;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetFiltered(GendersFilterDTO filter);
        Task<Gender?> GetById(Guid id);
    }
}
