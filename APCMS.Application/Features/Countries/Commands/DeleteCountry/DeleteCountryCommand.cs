using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
