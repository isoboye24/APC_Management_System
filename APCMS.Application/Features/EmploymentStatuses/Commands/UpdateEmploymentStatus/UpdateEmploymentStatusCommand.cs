using APCMS.Application.Utilities;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.UpdateEmploymentStatus
{
    public class UpdateEmploymentStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
