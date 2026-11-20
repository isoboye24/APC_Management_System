using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Features.Positions.Queries.GetPositionLists;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Nationalities.Queries.GetNationalityLists
{
    public class GetNationalityListsQueryHandler : IRequestHandler<GetNationalityListsQuery, PaginatedDTO<NationalityListsDTO>>
    {
        private readonly INationalityRepository _repository;
        public GetNationalityListsQueryHandler(INationalityRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<NationalityListsDTO>> Handle(GetNationalityListsQuery request)
        {
            var nationalities = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var nationalityList = nationalities.Select(n => n.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<NationalityListsDTO>
            {
                Items = nationalityList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
