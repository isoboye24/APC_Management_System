using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.PaymentStatuses.Commands.UpdatePaymentStatus
{
    public class UpdatePaymentStatusCommandHandler : IRequestHandler<UpdatePaymentStatusCommand>
    {
        private readonly IPaymentStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePaymentStatusCommandHandler(IPaymentStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePaymentStatusCommand request)
        {
            var paymentStatus = await _repository.GetById(request.Id);

            if (paymentStatus is null)
            {
                throw new NotFoundException("Payment status is required");
            }
            paymentStatus.UpdateName(request.Name);

            try
            {
                await _repository.Update(paymentStatus);
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
