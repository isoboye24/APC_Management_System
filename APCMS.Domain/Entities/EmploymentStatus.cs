using APCMS.Domain.Exceptions;

namespace APCMS.Domain.Entities
{   
    public class EmploymentStatus : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public EmploymentStatus(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private EmploymentStatus()
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
                throw new BusinessRuleException("Employment status's name is required.");
            }
        }
    }
}
