namespace APCMS.Application.Features.PaymentStatuses.Queries.GetDeletedPaymentStatusLists
{
    public class DeletedPaymentStatusFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
