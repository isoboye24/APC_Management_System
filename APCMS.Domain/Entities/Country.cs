using APCMS.Domain.Exceptions;

namespace APCMS.Domain.Entities
{
    public class Country : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public Country(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private Country()
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
                throw new BusinessRuleException("Country's name is required.");
            }
        }
    }
}
