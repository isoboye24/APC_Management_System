using APCMS.Application.Utilities;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.DeleteEmploymentStatus
{
    public class DeleteEmploymentStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
