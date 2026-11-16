namespace APCMS.Application.Features.Positions.Queries.GetPostionLists
{
    public class PositionFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
