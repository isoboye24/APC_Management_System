using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Professions.Queries.GetDeletedProfessionLists
{
    public class GetDeletedProfessionListsQueryHandler : IRequestHandler<GetDeletedProfessionListsQuery, PaginatedDTO<DeletedProfessionListsDTO>>
    {
        private readonly IProfessionRepository _repository;

        public GetDeletedProfessionListsQueryHandler(IProfessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedProfessionListsDTO>> Handle(GetDeletedProfessionListsQuery request)
        {
            var professions = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var professionList = professions.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedProfessionListsDTO>
            {
                Items = professionList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
