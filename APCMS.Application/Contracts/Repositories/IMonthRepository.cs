using APCMS.Application.Features.Months.GetMonthsList;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface IMonthRepository
    {
        Task<IEnumerable<Month>> GetFiltered(MonthsFilterDTO filter);

        Task<Month?> GetById(int id);

        Task<int> GetTotalAmountOfRecords();
    }
}
