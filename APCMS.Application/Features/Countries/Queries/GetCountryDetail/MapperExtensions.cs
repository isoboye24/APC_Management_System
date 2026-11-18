using APCMS.Domain.Entities;

namespace APCMS.Application.Features.Countries.Queries.GetCountryDetail
{
    public static class MapperExtensions
    {
        public static CountryDetailDTO ToDTO(this Country country)
        {
            return new CountryDetailDTO
            {
                Id = country.Id,
                Name = country.Name
            };
        }
    }
}
