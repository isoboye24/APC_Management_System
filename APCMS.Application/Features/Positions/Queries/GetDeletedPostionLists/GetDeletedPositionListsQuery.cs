using APCMS.Application.Features.Positions.Queries.GetDeletedPostionLists;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Positions.Queries.GetDeletedPositionLists
{
    public class GetDeletedPositionListsQuery : DeletedPositionsFilterDTO, IRequest<PaginatedDTO<DeletedPositionListsDTO>>
    {
    }
}
