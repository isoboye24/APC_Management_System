using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Positions.Commands.DeletePosition
{
    public class DeletePositionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
