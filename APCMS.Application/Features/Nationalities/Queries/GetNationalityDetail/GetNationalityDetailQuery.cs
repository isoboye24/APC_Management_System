using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Queries.GetNationalityDetail
{
    public class GetNationalityDetailQuery : IRequest<NationalityDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
