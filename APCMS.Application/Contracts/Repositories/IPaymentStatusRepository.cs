using APCMS.Application.Features.PaymentStatuses.Queries.GetDeletedPaymentStatusLists;
using APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusLists;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface IPaymentStatusRepository : IRepository<PaymentStatus>
    {
        Task<bool> Exists(string name, bool isDeleted = false);
        Task<IEnumerable<PaymentStatus>> GetFiltered(PaymentStatusFilterDTO filter);

        Task<IEnumerable<PaymentStatus>> GetDeletedFiltered(DeletedPaymentStatusFilterDTO filter);
    }
}
