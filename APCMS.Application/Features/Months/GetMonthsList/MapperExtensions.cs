using APCMS.Domain.Entities;

namespace APCMS.Application.Features.Months.GetMonthsList
{
    internal static class MapperExtensions
    {
        internal static MonthListsDTO ToDTO(this Month month)
        {
            return new MonthListsDTO
            {
                Id = month.Id,
                Name = month.Name
            };
        }
    }
}
