using APCMS.Domain.Exceptions;

namespace APCMS.Domain.Entities
{
    public class PaymentStatus : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public PaymentStatus(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private PaymentStatus()
        {

        }

        public void UpdateName(string name)
        {
            ValidateName(name);
            Name = name;
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException("Payment status's name is required.");
            }
        }
    }
}
