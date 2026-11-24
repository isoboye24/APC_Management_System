using APCMS.Domain.Entities;

namespace APCMS.Application.Features.PaymentStatuses.Queries.GetPaymentStatusDetail
{
    internal static class MapperExtensions
    {
        public static PaymentStatusDetailDTO ToDTO(this PaymentStatus paymentStatus)
        {
            return new PaymentStatusDetailDTO
            {
                Id = paymentStatus.Id,
                Name = paymentStatus.Name
            };
        }
    }
}
