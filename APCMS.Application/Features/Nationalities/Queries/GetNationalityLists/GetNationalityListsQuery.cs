using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Nationalities.Queries.GetNationalityLists
{
    public class GetNationalityListsQuery : NationalityFilterDTO, IRequest<PaginatedDTO<NationalityListsDTO>>
    {
    }
}
