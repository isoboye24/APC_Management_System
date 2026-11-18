namespace APCMS.Application.Features.Countries.Queries.GetCountryLists
{
    public class CountryFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
