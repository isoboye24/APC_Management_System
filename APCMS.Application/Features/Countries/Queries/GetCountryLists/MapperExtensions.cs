namespace APCMS.Application.Features.Countries.Queries.GetCountryLists
{
    internal static class MapperExtensions
    {
        internal static CountryListsDTO ToDTO(this Domain.Entities.Country country)
        {
            return new CountryListsDTO
            {
                Id = country.Id,
                Name = country.Name
            };
        }
    }
}
