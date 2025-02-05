using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Api_Blog.Entities.Configuration
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(150);
            builder.Property(p => p.DateOfCreation).HasColumnType("date");
        }
    }
}
