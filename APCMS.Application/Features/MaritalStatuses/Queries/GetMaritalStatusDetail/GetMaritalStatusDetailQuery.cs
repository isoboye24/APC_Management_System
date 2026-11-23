using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusDetail
{
    public class GetMaritalStatusDetailQuery : IRequest<MaritalStatusDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
