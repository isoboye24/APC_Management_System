using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
