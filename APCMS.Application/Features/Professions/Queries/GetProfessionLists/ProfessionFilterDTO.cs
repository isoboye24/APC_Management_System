namespace APCMS.Application.Features.Professions.Queries.GetProfessionLists
{
    public class ProfessionFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
