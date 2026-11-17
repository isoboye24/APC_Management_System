using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.Genders.GetGenderList
{
    public class GetGenderListsQueryHandler : IRequestHandler<GetGenderListsQuery, PaginatedDTO<GenderListsDTO>>
    {
        private readonly IGenderRepository _repository;
        public GetGenderListsQueryHandler(IGenderRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<GenderListsDTO>> Handle(GetGenderListsQuery request)
        {
            var genders = await _repository.GetFiltered(request);
            var genderLists = genders.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<GenderListsDTO>
            {
                Items = genderLists,
            };

            return paginatedResult;
        }
    }
}
