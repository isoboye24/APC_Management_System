using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.PaymentStatuses.Commands.DeletePaymentStatus
{
    public class DeletePaymentStatusCommandHandler : IRequestHandler<DeletePaymentStatusCommand>
    {
        private readonly IPaymentStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePaymentStatusCommandHandler(IPaymentStatusRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePaymentStatusCommand request)
        {
            var paymentStatus = await _repository.GetById(request.Id);

            if (paymentStatus is null)
            {
                throw new NotFoundException("Payment status not found");
            }

            try
            {
                await _repository.Delete(paymentStatus);
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
