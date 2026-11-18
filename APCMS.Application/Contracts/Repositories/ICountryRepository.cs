using APCMS.Application.Features.Countries.Queries.GetCountryLists;
using APCMS.Application.Features.Countries.Queries.GetDeletedCountryLists;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<bool> Exists(string name, bool isDeleted = false);
        Task<IEnumerable<Country>> GetFiltered(CountriesFilterDTO filter);
        Task<IEnumerable<Country>> GetDeletedFiltered(DeletedCountriesFilterDTO filter);
    }
}
