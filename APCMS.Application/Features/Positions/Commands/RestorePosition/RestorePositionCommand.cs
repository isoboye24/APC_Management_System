using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Positions.Commands.RestorePosition
{
    public class RestorePositionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
