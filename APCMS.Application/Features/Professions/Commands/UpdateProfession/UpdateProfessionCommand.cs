using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Commands.UpdateProfession
{
    public class UpdateProfessionCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
