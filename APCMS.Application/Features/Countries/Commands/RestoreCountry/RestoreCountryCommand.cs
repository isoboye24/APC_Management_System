using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Countries.Commands.RestoreCountry
{
    public class RestoreCountryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
