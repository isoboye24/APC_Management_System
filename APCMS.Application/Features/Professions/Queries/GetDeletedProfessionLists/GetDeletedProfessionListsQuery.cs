using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Professions.Queries.GetDeletedProfessionLists
{
    public class GetDeletedProfessionListsQuery : DeletedProfessionsFilterDTO, IRequest<PaginatedDTO<DeletedProfessionListsDTO>>
    {
    }
}
