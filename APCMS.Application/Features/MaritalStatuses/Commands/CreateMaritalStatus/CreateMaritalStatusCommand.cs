using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.CreateMaritalStatus
{
    public class CreateMaritalStatusCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
