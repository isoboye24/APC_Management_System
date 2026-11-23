using APCMS.Application.Utilities;

namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusDetail
{
    public class GetEmploymentStatusDetailQuery : IRequest<EmploymentStatusDetailDTO>
    {
        public required Guid Id { get; set; }    
    }
}
