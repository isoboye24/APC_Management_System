using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Commands.RestoreProfession
{
    public class RestoreProfessionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
