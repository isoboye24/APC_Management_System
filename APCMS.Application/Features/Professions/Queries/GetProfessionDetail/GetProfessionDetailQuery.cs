using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Queries.GetProfessionDetail
{
    public class GetProfessionDetailQuery : IRequest<ProfessionDetailDTO>
    {
        public required Guid Id { get; set; }    
    }
}
