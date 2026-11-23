namespace APCMS.Application.Features.EmploymentStatuses.Queries.GetDeletedEmploymentStatusLists
{
    public class DeletedEmploymentStatusFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
