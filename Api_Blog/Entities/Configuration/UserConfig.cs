using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Api_Blog.Entities.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name).HasMaxLength(150);
            builder.Property(u => u.LastName).HasMaxLength(150);
            builder.Property(u => u.Email).HasMaxLength(150);
            builder.Property(u => u.Password).HasMaxLength(150);
        }
    }
}
