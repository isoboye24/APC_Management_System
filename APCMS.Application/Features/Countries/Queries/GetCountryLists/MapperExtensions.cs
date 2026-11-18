namespace APCMS.Application.Features.Countries.Queries.GetCountryLists
{
    public static class MapperExtensions
    {
        public static CountryListsDTO ToDTO(this Domain.Entities.Country country)
        {
            return new CountryListsDTO
            {
                Id = country.Id,
                Name = country.Name
            };
        }
    }
}
