using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Professions.Commands.RestoreProfession
{
    public class RestoreProfessionCommandHandler : IRequestHandler<RestoreProfessionCommand>
    {
        private readonly IProfessionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RestoreProfessionCommandHandler(IProfessionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RestoreProfessionCommand request)
        {
            var profession = await _repository.GetById(request.Id);

            if (profession is null)
            {
                throw new NotFoundException("Profession not found");
            }

            try
            {
                await _repository.Restore(profession);
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
