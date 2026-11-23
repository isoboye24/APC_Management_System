using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.RestoreMaritalStatus
{
    public class RestoreMaritalStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
