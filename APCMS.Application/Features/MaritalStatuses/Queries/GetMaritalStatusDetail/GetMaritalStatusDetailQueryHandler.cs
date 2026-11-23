using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Queries.GetMaritalStatusDetail
{
    public class GetMaritalStatusDetailQueryHandler : IRequestHandler<GetMaritalStatusDetailQuery, MaritalStatusDetailDTO>
    {
        private readonly IMaritalStatusRepository _repository;

        public GetMaritalStatusDetailQueryHandler(IMaritalStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<MaritalStatusDetailDTO> Handle(GetMaritalStatusDetailQuery request)
        {
            var maritalStatus = await _repository.GetById(request.Id);

            if (maritalStatus is null)
            {
                throw new NotFoundException("Marital status is not found");
            }

            return maritalStatus.ToDTO();
        }
    }
}
