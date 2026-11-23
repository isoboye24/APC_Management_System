using APCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APCMS.Persistence.Configurations
{
    public class EmploymentStatusConfig : IEntityTypeConfiguration<EmploymentStatus>
    {
        public void Configure(EntityTypeBuilder<EmploymentStatus> builder)
        {
            builder.Property(prop => prop.Name)
               .IsRequired()
               .HasMaxLength(250);
        }    
    }
}
