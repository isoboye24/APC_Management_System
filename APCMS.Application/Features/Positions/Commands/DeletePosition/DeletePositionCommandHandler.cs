using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Positions.Commands.DeletePosition
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand>
    {
        private readonly IPositionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePositionCommandHandler(IPositionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePositionCommand request)
        {
            var position = await _repository.GetById(request.Id);

            if (position is null)
            {
                throw new NotFoundException("Position not found");
            }

            try
            {
                await _repository.Delete(position);
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
