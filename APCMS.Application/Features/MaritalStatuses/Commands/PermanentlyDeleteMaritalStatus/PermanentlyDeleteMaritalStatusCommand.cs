using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.PermanentlyDeleteMaritalStatus
{
    public class PermanentlyDeleteMaritalStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
