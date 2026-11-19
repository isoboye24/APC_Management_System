namespace APCMS.Application.Features.Nationalities.Queries.GetDeletedNationalityLists
{
    public class DeletedNationalityFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
