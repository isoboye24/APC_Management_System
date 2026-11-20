using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Commands.RestoreNationality
{
    public class RestoreNationalityCommandHandler : IRequestHandler<RestoreNationalityCommand>
    {
        private readonly INationalityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RestoreNationalityCommandHandler(INationalityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RestoreNationalityCommand request)
        {
            var nationality = await _repository.GetById(request.Id);

            if (nationality is null)
            {
                throw new NotFoundException("Nationality not found");
            }

            try
            {
                await _repository.Restore(nationality);
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
