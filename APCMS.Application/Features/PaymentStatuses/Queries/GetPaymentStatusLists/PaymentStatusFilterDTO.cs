namespace APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusLists
{
    public class PaymentStatusFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
