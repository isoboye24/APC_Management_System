using APCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APCMS.Persistence.Configurations
{
    public class MembershipCategoryConfig : IEntityTypeConfiguration<MembershipCategory>
    {
        public void Configure(EntityTypeBuilder<MembershipCategory> builder)
        {
            builder.Property(prop => prop.Name)
              .IsRequired()
              .HasMaxLength(250);
        }
    }
}
