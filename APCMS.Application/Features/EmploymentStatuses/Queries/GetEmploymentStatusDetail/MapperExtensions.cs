namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusDetail
{
    internal static class MapperExtensions
    {
        internal static EmploymentStatusDetailDTO ToDTO(this Domain.Entities.EmploymentStatus employmentStatus)
        {
            return new EmploymentStatusDetailDTO
            {
                Id = employmentStatus.Id,
                Name = employmentStatus.Name
            };
        }
    }
}
