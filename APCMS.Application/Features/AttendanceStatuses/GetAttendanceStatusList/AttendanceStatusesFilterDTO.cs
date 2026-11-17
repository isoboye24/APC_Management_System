namespace APCMS.Application.Features.AttendanceStatuses.GetAttendanceStatusList
{
    public class AttendanceStatusesFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
