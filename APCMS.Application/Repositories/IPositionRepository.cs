using APCMS.Application.Features.Positions.Queries.GetDeletedPostionLists;
using APCMS.Application.Features.Positions.Queries.GetPostionLists;
using APCMS.Domain.Entities;

namespace APCMS.Application.Contracts.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<bool> Exists(string name, bool isDeleted = false);
        Task<IEnumerable<Position>> GetFiltered(PositionFilterDTO filter);

        Task<IEnumerable<Position>> GetDeletedFiltered(DeletedPositionsFilterDTO filter);
    }
}
