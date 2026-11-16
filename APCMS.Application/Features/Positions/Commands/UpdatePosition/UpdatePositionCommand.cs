using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Positions.Commands.UpdatePosition
{
    public class UpdatePositionCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
