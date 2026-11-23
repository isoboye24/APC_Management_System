using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.DeleteMaritalStatus
{
    public class DeleteMaritalStatusCommand : IRequest
    {
        public required Guid Id { get; set; }    
    }
}
