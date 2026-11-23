using APCMS.Application.Utilities;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.RestoreEmploymentStatus
{
    public class RestoreEmploymentStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
