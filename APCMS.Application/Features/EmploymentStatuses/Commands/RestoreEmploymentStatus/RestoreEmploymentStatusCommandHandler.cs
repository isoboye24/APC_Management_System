using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.RestoreEmploymentStatus
{
    public class RestoreEmploymentStatusCommandHandler : IRequestHandler<RestoreEmploymentStatusCommand>
    {
        private readonly IEmploymentStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RestoreEmploymentStatusCommandHandler(IEmploymentStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RestoreEmploymentStatusCommand request)
        {
            var employmentStatus = await _repository.GetById(request.Id);

            if (employmentStatus is null)
            {
                throw new NotFoundException("Employment status not found");
            }

            try
            {
                await _repository.Restore(employmentStatus);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
