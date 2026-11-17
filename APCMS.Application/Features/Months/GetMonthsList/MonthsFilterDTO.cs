namespace APCMS.Application.Features.Months.GetMonthsList
{
    public class MonthsFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 12;
        public string? Name { get; set; }
    }
}
