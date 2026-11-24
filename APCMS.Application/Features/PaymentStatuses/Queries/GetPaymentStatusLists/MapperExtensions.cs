namespace APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusLists
{
    internal static class MapperExtensions
    {
        internal static PaymentStatusListsDTO ToDTO(this Domain.Entities.PaymentStatus paymentStatus)
        {
            return new PaymentStatusListsDTO
            {
                Id = paymentStatus.Id,
                Name = paymentStatus.Name
            };
        }
    }
}
