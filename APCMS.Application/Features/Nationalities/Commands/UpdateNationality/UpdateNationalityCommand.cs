using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Commands.UpdateNationality
{
    public class UpdateNationalityCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
