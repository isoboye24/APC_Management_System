using APCMS.Domain.Exceptions;

namespace APCMS.Domain.Entities
{
    public class Profession : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public Profession(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private Profession()
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
                throw new BusinessRuleException("Profession's name is required.");
            }
        }
    }
}
