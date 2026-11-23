using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Commands.PermanentlyDeleteProfession
{
    public class PermanentlyDeleteProfessionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
