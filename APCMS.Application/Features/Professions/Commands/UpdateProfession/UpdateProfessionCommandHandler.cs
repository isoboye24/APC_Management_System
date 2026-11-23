using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Commands.UpdateProfession
{
    public class UpdateProfessionCommandHandler : IRequestHandler<UpdateProfessionCommand>
    {
        private readonly IProfessionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProfessionCommandHandler(IProfessionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProfessionCommand request)
        {
            var profession = await _repository.GetById(request.Id);

            if (profession is null)
            {
                throw new NotFoundException("Profession is required");
            }
            profession.UpdateName(request.Name);

            try
            {
                await _repository.Update(profession);
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
