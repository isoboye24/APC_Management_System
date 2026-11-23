using APCMS.Domain.Exceptions;

namespace APCMS.Domain.Entities
{
    public class MaritalStatus : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public MaritalStatus(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private MaritalStatus()
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
                throw new BusinessRuleException("Marital status's name is required.");
            }
        }
    }
}
