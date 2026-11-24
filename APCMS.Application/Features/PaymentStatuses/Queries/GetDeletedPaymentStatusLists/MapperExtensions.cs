using APCMS.Domain.Entities;

namespace APCMS.Application.Features.PaymentStatuses.Queries.GetDeletedPaymentStatusLists
{
    internal static class MapperExtensions
    {
        internal static DeletedPaymentStatusListDTO ToDTO(this PaymentStatus paymentStatus)
        {
            return new DeletedPaymentStatusListDTO
            {
                Id = paymentStatus.Id,
                Name = paymentStatus.Name
            };
        }
    }
}
