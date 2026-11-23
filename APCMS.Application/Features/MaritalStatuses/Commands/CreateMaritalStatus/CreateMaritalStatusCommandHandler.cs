using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;
using APCMS.Domain.Entities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.CreateMaritalStatus
{
    public class CreateMaritalStatusCommandHandler : IRequestHandler<CreateMaritalStatusCommand, Guid>
    {
        private readonly IMaritalStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMaritalStatusCommandHandler(IMaritalStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateMaritalStatusCommand request)
        {
            bool exists = await _repository.Exists(request.Name);

            if (exists)
            {
                throw new CustomValidationException("The Marital Status already exists.");
            }
            else
            {
                var maritalStatus = new MaritalStatus(request.Name);
                try
                {
                    var result = await _repository.Add(maritalStatus);
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
