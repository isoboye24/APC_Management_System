namespace APCMS.Application.Features.Professions.Queries.GetProfessionLists
{
    internal static class MapperExtensions
    {
        internal static ProfessionListsDTO ToDTO(this Domain.Entities.Profession profession)
        {
            return new ProfessionListsDTO
            {
                Id = profession.Id,
                Name = profession.Name
            };
        }
    }
}
