using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;
using APCMS.Domain.Entities;

namespace APCMS.Application.Features.PaymentStatuses.Commands.CreatePaymentStatus
{
    public class CreatePaymentStatusCommandHandler : IRequestHandler<CreatePaymentStatusCommand, Guid>
    {
        private readonly IPaymentStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePaymentStatusCommandHandler(IPaymentStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePaymentStatusCommand request)
        {
            bool exists = await _repository.Exists(request.Name);

            if (exists)
            {
                throw new CustomValidationException("The payment status already exists.");
            }
            else
            {
                var paymentStatus = new PaymentStatus(request.Name);
                try
                {
                    var result = await _repository.Add(paymentStatus);
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
