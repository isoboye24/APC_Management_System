using APCMS.Application.Utilities;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.CreateEmploymentStatus
{
    public class CreateEmploymentStatusCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
