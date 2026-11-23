using APCMS.Domain.Entities;

namespace APCMS.Application.Features.Professions.Queries.GetDeletedProfessionLists
{
    internal static class MapperExtensions
    {
        internal static DeletedProfessionListsDTO ToDTO(this Profession profession)
        {
            return new DeletedProfessionListsDTO
            {
                Id = profession.Id,
                Name = profession.Name
            };
        }
    }
}
