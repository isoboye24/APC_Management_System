using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;
using APCMS.Domain.Entities;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.CreateEmploymentStatus
{
    public class CreateEmploymentStatusCommandHandler : IRequestHandler<CreateEmploymentStatusCommand, Guid>
    {
        private readonly IEmploymentStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmploymentStatusCommandHandler(IEmploymentStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateEmploymentStatusCommand request)
        {
            bool exists = await _repository.Exists(request.Name);

            if (exists)
            {
                throw new CustomValidationException("The employment status already exists.");
            }
            else
            {
                var employmentStatus = new EmploymentStatus(request.Name);
                try
                {
                    var result = await _repository.Add(employmentStatus);
                    await _unitOfWork.Commit();
                    return result.Id;
                }
                catch (Exception)
                {
                    await _unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
