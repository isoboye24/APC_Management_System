using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Commands.DeleteProfession
{
    public class DeleteProfessionCommandHandler : IRequestHandler<DeleteProfessionCommand>
    {
        private readonly IProfessionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProfessionCommandHandler(IProfessionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProfessionCommand request)
        {
            var profession = await _repository.GetById(request.Id);

            if (profession is null)
            {
                throw new NotFoundException("Profession not found");
            }

            try
            {
                await _repository.Delete(profession);
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
