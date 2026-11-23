using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Commands.DeleteProfession
{
    public class DeleteProfessionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
