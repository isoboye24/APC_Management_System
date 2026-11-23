using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.UpdateMaritalStatus
{
    public class UpdateMaritalStatusCommandHandler : IRequestHandler<UpdateMaritalStatusCommand>
    {
        private readonly IMaritalStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMaritalStatusCommandHandler(IMaritalStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateMaritalStatusCommand request)
        {
            var maritalStatus = await _repository.GetById(request.Id);

            if (maritalStatus is null)
            {
                throw new NotFoundException("Marital status is required");
            }
            maritalStatus.UpdateName(request.Name);

            try
            {
                await _repository.Update(maritalStatus);
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
