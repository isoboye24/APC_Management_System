namespace APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusLists
{
    internal static class MapperExtensions
    {
        internal static MaritalStatusListsDTO ToDTO(this Domain.Entities.MaritalStatus maritalStatus)
        {
            return new MaritalStatusListsDTO
            {
                Id = maritalStatus.Id,
                Name = maritalStatus.Name
            };
        }
    }
}
