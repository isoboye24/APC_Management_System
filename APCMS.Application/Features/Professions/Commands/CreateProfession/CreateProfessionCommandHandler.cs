using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;
using APCMS.Domain.Entities;

namespace APCMS.Application.Features.Professions.Commands.CreateProfession
{
    public class CreateProfessionCommandHandler : IRequestHandler<CreateProfessionCommand, Guid>
    {
        private readonly IProfessionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProfessionCommandHandler(IProfessionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProfessionCommand request)
        {
            bool exists = await _repository.Exists(request.Name);

            if (exists)
            {
                throw new CustomValidationException("The profession already exists.");
            }
            else
            {
                var profession = new Profession(request.Name);
                try
                {
                    var result = await _repository.Add(profession);
                    await _unitOfWork.Commit();
                    return result.Id;
                }
                catch (Exception)
                {
                    await _unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
