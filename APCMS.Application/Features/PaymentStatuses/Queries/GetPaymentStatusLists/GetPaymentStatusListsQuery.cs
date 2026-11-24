using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusLists
{
    public class GetPaymentStatusListsQuery : PaymentStatusFilterDTO, IRequest<PaginatedDTO<PaymentStatusListsDTO>>
    {
    }
}
