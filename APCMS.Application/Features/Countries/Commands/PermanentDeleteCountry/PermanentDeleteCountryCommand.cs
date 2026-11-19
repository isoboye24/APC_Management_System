using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Countries.Commands.PermanentDeleteCountry
{
    public class PermanentDeleteCountryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
