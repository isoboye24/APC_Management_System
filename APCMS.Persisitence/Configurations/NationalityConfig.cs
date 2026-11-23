using APCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APCMS.Persistence.Configurations
{
    public class NationalityConfig : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.Property(prop => prop.Name)
               .IsRequired()
               .HasMaxLength(250);
        }
    }
}
