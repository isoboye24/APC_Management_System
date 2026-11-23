using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Commands.CreateProfession
{
    public class CreateProfessionCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
