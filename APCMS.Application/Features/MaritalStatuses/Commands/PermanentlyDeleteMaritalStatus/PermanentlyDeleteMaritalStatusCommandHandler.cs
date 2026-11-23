using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.PermanentlyDeleteMaritalStatus
{
    public class PermanentlyDeleteMaritalStatusCommandHandler : IRequestHandler<PermanentlyDeleteMaritalStatusCommand>
    {
        private readonly IMaritalStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PermanentlyDeleteMaritalStatusCommandHandler(IMaritalStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermanentlyDeleteMaritalStatusCommand request)
        {
            var maritalStatus = await _repository.GetById(request.Id);

            if (maritalStatus is null)
            {
                throw new NotFoundException("Marital status not found");
            }

            try
            {
                await _repository.DeletePermanently(maritalStatus);
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
