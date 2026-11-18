using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
