using APCMS.Application.Utilities;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.PermanentlyDeleteEmploymentStatus
{
    public class PermanentlyDeleteEmploymentStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
