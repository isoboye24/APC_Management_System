using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Commands.PermanentlyDeleteNationality
{
    public class PermanentDeleteNationalityCommandHandler : IRequestHandler<PermanentDeleteNationalityCommand>
    {
        private readonly INationalityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PermanentDeleteNationalityCommandHandler(INationalityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermanentDeleteNationalityCommand request)
        {
            var nationality = await _repository.GetById(request.Id);

            if (nationality is null)
            {
                throw new NotFoundException("Nationality not found");
            }

            try
            {
                await _repository.DeletePermanently(nationality);
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
