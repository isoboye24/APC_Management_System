using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Commands.PermanentlyDeleteNationality
{
    public class PermanentDeleteNationalityCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
