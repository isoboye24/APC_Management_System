using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;

namespace APCMS.Application.Features.Positions.Queries.GetPositionDetail
{
    public class GetPositionDetailQueryHandler : IRequestHandler<GetPositionDetailQuery, PositionDetailDTO>
    {
        private readonly IPositionRepository _repository;

        public GetPositionDetailQueryHandler(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PositionDetailDTO> Handle(GetPositionDetailQuery request)
        {
            var position = await _repository.GetById(request.Id);

            if (position is null)
            {
                throw new NotFoundException("Position is not found");
            }

            return position.ToDTO();
        }
    }
}
