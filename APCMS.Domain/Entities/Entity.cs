using APCMS.Domain.Common;

namespace APCMS.Domain.Entities
{
    public abstract class Entity : Auditable
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.CreateVersion7();
        }
    }
}
