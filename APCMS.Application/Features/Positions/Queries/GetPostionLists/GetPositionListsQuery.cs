using APCMS.Application.Features.Positions.Queries.GetPostionLists;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Positions.Queries.GetPositionLists
{
    public class GetPositionListsQuery : PositionFilterDTO, IRequest<PaginatedDTO<PositionListsDTO>>
    {
    }
}
