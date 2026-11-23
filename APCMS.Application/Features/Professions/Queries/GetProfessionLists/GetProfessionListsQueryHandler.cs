using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Professions.Queries.GetProfessionLists
{
    public class GetProfessionListsQueryHandler : IRequestHandler<GetProfessionListsQuery, PaginatedDTO<ProfessionListsDTO>>
    {
        private readonly IProfessionRepository _repository;

        public GetProfessionListsQueryHandler(IProfessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<ProfessionListsDTO>> Handle(GetProfessionListsQuery request)
        {
            var professions = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var professionList = professions.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<ProfessionListsDTO>
            {
                Items = professionList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
