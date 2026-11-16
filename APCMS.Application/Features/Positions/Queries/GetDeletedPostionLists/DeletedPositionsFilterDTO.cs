namespace APCMS.Application.Features.Positions.Queries.GetDeletedPostionLists
{
    public class DeletedPositionsFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
