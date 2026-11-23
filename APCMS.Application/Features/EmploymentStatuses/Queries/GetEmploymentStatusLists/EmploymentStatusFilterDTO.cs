namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetEmploymentStatusLists
{
    public class EmploymentStatusFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
