using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Queries.GetNationalityDetail
{
    public class GetNationalityDetailQueryHandler : IRequestHandler<GetNationalityDetailQuery, NationalityDetailDTO>
    {
        private readonly INationalityRepository _repository;
        public GetNationalityDetailQueryHandler(INationalityRepository repository)
        {
            _repository = repository;
        }

        public async Task<NationalityDetailDTO> Handle(GetNationalityDetailQuery request)
        {
            var nationality = await _repository.GetById(request.Id);

            if (nationality is null)
            {
                throw new NotFoundException("Nationality is not found");
            }

            return nationality.ToDTO();
        }
    }
}
