using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
