using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.PaymentStatuses.Queries.GetDeletedPaymentStatusLists
{
    public class GetDeletedPaymentStatusListsQuery : DeletedPaymentStatusFilterDTO, IRequest<PaginatedDTO<DeletedPaymentStatusListDTO>>
    {
    }
}
