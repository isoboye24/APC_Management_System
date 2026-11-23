namespace APCMS.Application.Features.MaritalStatuses.Queries.GetDeletedMaritalStatusLists
{
    internal static class MapperExtensions
    {
        internal static DeletedMaritalStatusListsDTO ToDTO(this Domain.Entities.MaritalStatus maritalStatus)
        {
            return new DeletedMaritalStatusListsDTO
            {
                Id = maritalStatus.Id,
                Name = maritalStatus.Name
            };
        }
    }
}
