using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Nationalities.Queries.GetDeletedNationalityLists
{
    public class GetDeletedNationalityListsQueryHandler : IRequestHandler<GetDeletedNationalityListsQuery, PaginatedDTO<DeletedNationalityListsDTO>>
    {
        private readonly INationalityRepository _repository;

        public GetDeletedNationalityListsQueryHandler(INationalityRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedNationalityListsDTO>> Handle(GetDeletedNationalityListsQuery request)
        {
            var nationalities = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var nationalityList = nationalities.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedNationalityListsDTO>
            {
                Items = nationalityList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
