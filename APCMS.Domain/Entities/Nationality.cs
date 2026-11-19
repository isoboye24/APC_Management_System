using APCMS.Domain.Exceptions;

namespace APCMS.Domain.Entities
{
    public class Nationality : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public Nationality(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private Nationality()
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
                throw new BusinessRuleException("Nationality's name is required.");
            }
        }
    }
}
