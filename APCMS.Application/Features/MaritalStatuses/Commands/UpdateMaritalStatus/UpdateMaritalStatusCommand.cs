using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.UpdateMaritalStatus
{
    public class UpdateMaritalStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
