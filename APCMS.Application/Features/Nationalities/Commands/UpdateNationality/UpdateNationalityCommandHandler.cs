using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Nationalities.Commands.UpdateNationality
{
    public class UpdateNationalityCommandHandler : IRequestHandler<UpdateNationalityCommand>
    {
        private readonly INationalityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNationalityCommandHandler(INationalityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateNationalityCommand request)
        {
            var nationality = await _repository.GetById(request.Id);

            if (nationality is null)
            {
                throw new NotFoundException("Nationality is required");
            }
            nationality.UpdateName(request.Name);

            try
            {
                await _repository.Update(nationality);
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
