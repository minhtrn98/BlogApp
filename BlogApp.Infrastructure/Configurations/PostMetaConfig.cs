using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.Infrastructure.Configurations
{
    public class PostMetaConfig : IEntityTypeConfiguration<PostMeta>
    {
        public void Configure(EntityTypeBuilder<PostMeta> builder)
        {
            builder.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PostId)
                .IsRequired();
        }
    }
}
