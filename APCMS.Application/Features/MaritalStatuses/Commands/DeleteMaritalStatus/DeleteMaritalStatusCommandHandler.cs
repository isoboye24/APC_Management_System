using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.DeleteMaritalStatus
{
    public class DeleteMaritalStatusCommandHandler : IRequestHandler<DeleteMaritalStatusCommand>
    {
        private readonly IMaritalStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMaritalStatusCommandHandler(IMaritalStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMaritalStatusCommand request)
        {
            var maritalStatus = await _repository.GetById(request.Id);

            if (maritalStatus is null)
            {
                throw new NotFoundException("Marital status not found");
            }

            try
            {
                await _repository.Delete(maritalStatus);
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
