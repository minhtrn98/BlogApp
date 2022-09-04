using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.Infrastructure.Configurations
{
    public class PostCommentConfig : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PublishedAt)
                .IsRequired(false);

            builder.Property(e => e.Content)
                .IsRequired();

            builder.Property(e => e.PostId)
                .IsRequired();

            builder.Property(e => e.ParentId)
                .IsRequired();
        }
    }
}
