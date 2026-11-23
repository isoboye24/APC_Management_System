using APCMS.Domain.Entities;

namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetDeletedEmploymentStatusLists
{
    internal static class MapperExtensions
    {
        internal static DeletedEmploymentStatusListsDTO ToDTO(this EmploymentStatus employmentStatus)
        {
            return new DeletedEmploymentStatusListsDTO
            {
                Id = employmentStatus.Id,
                Name = employmentStatus.Name
            };
        }
    }
}
