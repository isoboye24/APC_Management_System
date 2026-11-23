using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MaritalStatuses.Commands.RestoreMaritalStatus
{
    public class RestoreMaritalStatusCommandHandler : IRequestHandler<RestoreMaritalStatusCommand>
    {
        private readonly IMaritalStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RestoreMaritalStatusCommandHandler(IMaritalStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RestoreMaritalStatusCommand request)
        {
            var maritalStatus = await _repository.GetById(request.Id);

            if (maritalStatus is null)
            {
                throw new NotFoundException("MaritalStatus not found");
            }

            try
            {
                await _repository.Restore(maritalStatus);
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
