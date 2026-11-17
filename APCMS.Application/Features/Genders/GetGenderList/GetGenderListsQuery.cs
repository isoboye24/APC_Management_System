using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Genders.GetGenderList
{
    public class GetGenderListsQuery : GendersFilterDTO, IRequest<PaginatedDTO<GenderListsDTO>>
    {
    }
}
