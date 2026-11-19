namespace APCMS.Application.Features.Countries.Queries.GetDeletedCountryLists
{
    internal static class MapperExtensions
    {
        internal static DeletedCountryListsDTO ToDTO(this Domain.Entities.Country country)
        {
            return new DeletedCountryListsDTO
            {
                Id = country.Id,
                Name = country.Name
            };
        }
    }
}
