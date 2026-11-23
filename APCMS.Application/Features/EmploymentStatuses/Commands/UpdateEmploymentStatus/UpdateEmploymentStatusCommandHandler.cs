using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.UpdateEmploymentStatus
{
    public class UpdateEmploymentStatusCommandHandler : IRequestHandler<UpdateEmploymentStatusCommand>
    {
        private readonly IEmploymentStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmploymentStatusCommandHandler(IEmploymentStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateEmploymentStatusCommand request)
        {
            var employmentStatus = await _repository.GetById(request.Id);

            if (employmentStatus is null)
            {
                throw new NotFoundException("EmploymentStatus is required");
            }
            employmentStatus.UpdateName(request.Name);

            try
            {
                await _repository.Update(employmentStatus);
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
