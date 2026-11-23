using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Queries.GetProfessionDetail
{
    public class GetProfessionDetailQueryHandler : IRequestHandler<GetProfessionDetailQuery, ProfessionDetailDTO>
    {
        private readonly IProfessionRepository _repository;

        public GetProfessionDetailQueryHandler(IProfessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProfessionDetailDTO> Handle(GetProfessionDetailQuery request)
        {
            var profession = await _repository.GetById(request.Id);

            if (profession is null)
            {
                throw new NotFoundException("Profession is not found");
            }

            return profession.ToDTO();
        }
    }
}
