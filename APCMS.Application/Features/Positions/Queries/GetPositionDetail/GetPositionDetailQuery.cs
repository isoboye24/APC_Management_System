using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Positions.Queries.GetPositionDetail
{
    public class GetPositionDetailQuery : IRequest<PositionDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
