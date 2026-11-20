namespace APCMS.Application.Features.Nationalities.Queries.GetNationalityLists
{
    internal static class MapperExtensions
    {
        internal static NationalityListsDTO ToDTO(this Domain.Entities.Nationality nationality)
        {
            return new NationalityListsDTO
            {
                Id = nationality.Id,
                Name = nationality.Name
            };
        }
    }
}
