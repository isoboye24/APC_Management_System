using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusDetail
{
    public class GetEmploymentStatusDetailQueryHandler : IRequestHandler<GetEmploymentStatusDetailQuery, EmploymentStatusDetailDTO>
    {
        private readonly IEmploymentStatusRepository _repository;
        public GetEmploymentStatusDetailQueryHandler(IEmploymentStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<EmploymentStatusDetailDTO> Handle(GetEmploymentStatusDetailQuery request)
        {
            var employmentStatus = await _repository.GetById(request.Id);

            if (employmentStatus is null)
            {
                throw new NotFoundException("Employment status is not found");
            }

            return employmentStatus.ToDTO();
        }
    }
}
