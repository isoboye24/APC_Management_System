using APCMS.Domain.Entities;

namespace APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusDetail
{
    internal static class MapperExtensions
    {
        public static MaritalStatusDetailDTO ToDTO(this MaritalStatus maritalStatus)
        {
            return new MaritalStatusDetailDTO
            {
                Id = maritalStatus.Id,
                Name = maritalStatus.Name
            };
        }
    }
}
