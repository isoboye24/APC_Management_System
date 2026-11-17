using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Utilities;
using APCMS.Application.Utilities.Common;

namespace APCMS.Application.Features.AttendanceStatuses.GetAttendanceStatusList
{
    public class GetAttendanceStatusListsQueryHandler : IRequestHandler<GetAttendanceStatusListsQuery, PaginatedDTO<AttendanceStatusListsDTO>>
    {
        private readonly IAttendanceStatusRepository _repository;
        public GetAttendanceStatusListsQueryHandler(IAttendanceStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<AttendanceStatusListsDTO>> Handle(GetAttendanceStatusListsQuery request)
        {
            var attendanceStatuses = await _repository.GetFiltered(request);
            var attendanceStatusLists = attendanceStatuses.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<AttendanceStatusListsDTO>
            {
                Items = attendanceStatusLists,
            };

            return paginatedResult;
        }
    }
}
