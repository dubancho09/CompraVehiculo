using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.id).IsRequired();
            builder.Property(u => u.userName).IsRequired().HasMaxLength(40);
            builder.Property(u => u.email).IsRequired(false).HasMaxLength(100);
            builder.Property(u=> u.password).IsRequired();

        }
    }
}
