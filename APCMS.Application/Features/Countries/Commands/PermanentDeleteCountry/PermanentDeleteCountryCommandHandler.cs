using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Countries.Commands.PermanentDeleteCountry
{
    public class PermanentDeleteCountryCommandHandler : IRequestHandler<PermanentDeleteCountryCommand>
    {
        private readonly ICountryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PermanentDeleteCountryCommandHandler(ICountryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermanentDeleteCountryCommand request)
        {
            var country = await _repository.GetById(request.Id);

            if (country is null)
            {
                throw new NotFoundException("Country not found");
            }

            try
            {
                await _repository.DeletePermanently(country);
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
