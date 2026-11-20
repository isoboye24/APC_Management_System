using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Nationalities.Queries.GetDeletedNationalityLists
{
    public class GetDeletedNationalityListsQuery : DeletedNationalityFilterDTO, IRequest<PaginatedDTO<DeletedNationalityListsDTO>>
    {
    }
}
