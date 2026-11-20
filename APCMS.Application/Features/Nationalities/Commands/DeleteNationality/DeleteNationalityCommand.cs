using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Commands.DeleteNationality
{
    public class DeleteNationalityCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
