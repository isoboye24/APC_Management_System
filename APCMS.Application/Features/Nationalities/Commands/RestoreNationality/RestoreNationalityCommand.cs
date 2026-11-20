using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Commands.RestoreNationality
{
    public class RestoreNationalityCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
