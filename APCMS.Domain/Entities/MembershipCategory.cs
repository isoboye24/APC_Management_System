using APCMS.Domain.Exceptions;

namespace APCMS.Domain.Entities
{
    public class MembershipCategory : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public MembershipCategory(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private MembershipCategory()
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
                throw new BusinessRuleException("Position's name is required.");
            }
        }
    }
}
