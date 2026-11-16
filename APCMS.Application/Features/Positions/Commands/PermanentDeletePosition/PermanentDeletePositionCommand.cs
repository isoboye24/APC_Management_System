using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Positions.Commands.PermanentDeletePosition
{
    public class PermanentDeletePositionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
