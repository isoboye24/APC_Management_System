using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Commands.CreateNationality
{
    public class CreateNationalityCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
