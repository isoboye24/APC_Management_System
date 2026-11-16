using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Positions.Queries.GetPositionLists
{
    public class GetPositionListsQueryHandler : IRequestHandler<GetPositionListsQuery, PaginatedDTO<PositionListsDTO>>
    {
        private readonly IPositionRepository _repository;
        public GetPositionListsQueryHandler(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<PositionListsDTO>> Handle(GetPositionListsQuery request)
        {
            var positions = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var positionList = positions.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<PositionListsDTO>
            {
                Items = positionList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
