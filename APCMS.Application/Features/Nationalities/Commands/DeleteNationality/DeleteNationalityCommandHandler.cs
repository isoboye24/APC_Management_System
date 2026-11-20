using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Commands.DeleteNationality
{
    public class DeleteNationalityCommandHandler : IRequestHandler<DeleteNationalityCommand>
    {
        private readonly INationalityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNationalityCommandHandler(INationalityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteNationalityCommand request)
        {
            var nationality = await _repository.GetById(request.Id);

            if (nationality is null)
            {
                throw new NotFoundException("Nationality not found");
            }

            try
            {
                await _repository.Delete(nationality);
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
