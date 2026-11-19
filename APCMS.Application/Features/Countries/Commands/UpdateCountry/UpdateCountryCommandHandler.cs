using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Countries.Commands.UpdateCountry
{    
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand>
    {
        private readonly ICountryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCountryCommandHandler(ICountryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCountryCommand request)
        {

            var country = await _repository.GetById(request.Id);

            if (country is null)
            {
                throw new NotFoundException("Country is required");
            }
            country.UpdateName(request.Name);

            try
            {
                await _repository.Update(country);
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
