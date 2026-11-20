using APCMS.Domain.Entities;

namespace APCMS.Application.Features.Nationalities.Queries.GetNationalityDetail
{
    internal static class MapperExtensions
    {
        internal static NationalityDetailDTO ToDTO(this Nationality nationality)
        {
            return new NationalityDetailDTO
            {
                Id = nationality.Id,
                Name = nationality.Name
            };
        }
    }
}
