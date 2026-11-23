using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Professions.Queries.GetProfessionLists
{
    public class GetProfessionListsQuery : ProfessionFilterDTO, IRequest<PaginatedDTO<ProfessionListsDTO>>
    {
    }
}
