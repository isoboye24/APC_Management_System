using APCMS.Domain.Entities;

namespace APCMS.Application.Features.Professions.Queries.GetProfessionDetail
{
    internal static class MapperExtensions
    {
        public static ProfessionDetailDTO ToDTO(this Profession profession)
        {
            return new ProfessionDetailDTO
            {
                Id = profession.Id,
                Name = profession.Name
            };
        }
    }
}
