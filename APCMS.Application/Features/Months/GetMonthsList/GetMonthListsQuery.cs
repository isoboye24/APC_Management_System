using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Months.GetMonthsList
{
    public class GetMonthListsQuery : MonthsFilterDTO, IRequest<PaginatedDTO<MonthListsDTO>>
    {
    }
}
