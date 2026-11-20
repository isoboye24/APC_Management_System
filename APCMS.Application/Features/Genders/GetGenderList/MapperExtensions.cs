using APCMS.Domain.Entities;

namespace APCMS.Application.Features.Genders.GetGenderList
{
    internal static class MapperExtensions
    {
        internal static GenderListsDTO ToDTO(this Gender gender)
        {
            return new GenderListsDTO
            {
                Id = gender.Id,
                Name = gender.Name
            };
        }
    }
}
