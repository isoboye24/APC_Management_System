namespace APCMS.Application.Features.Nationalities.Queries.GetDeletedNationalityLists
{
    internal static class MapperExtensions
    {
        internal static DeletedNationalityListsDTO ToDTO(this Domain.Entities.Nationality nationality)
        {
            return new DeletedNationalityListsDTO
            {
                Id = nationality.Id,
                Name = nationality.Name
            };
        }
    }
}
