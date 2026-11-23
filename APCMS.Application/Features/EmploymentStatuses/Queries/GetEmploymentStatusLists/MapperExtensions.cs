namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusLists
{
    internal static class MapperExtensions
    {
        internal static EmploymentStatusListsDTO ToDTO(this Domain.Entities.EmploymentStatus employmentStatus)
        {
            return new EmploymentStatusListsDTO
            {
                Id = employmentStatus.Id,
                Name = employmentStatus.Name
            };
        }
    }
}
