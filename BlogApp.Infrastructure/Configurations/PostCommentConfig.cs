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
                .IsRequired(false);

            builder.HasMany(e => e.PostComments).WithOne(e => e.Parent).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Parent).WithMany(e => e.PostComments).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
