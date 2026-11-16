using APCMS.Domain.Entities;

namespace APCMS.Application.Features.Positions.Queries.GetDeletedPositionLists
{
    internal static class MapperExtensions
    {
        internal static DeletedPositionListsDTO ToDTO(this Position position)
        {
            return new DeletedPositionListsDTO
            {
                Id = position.Id,
                Name = position.Name
            };
        }
    }
}
