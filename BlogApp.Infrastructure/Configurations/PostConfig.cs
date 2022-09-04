using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.Infrastructure.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(e => e.MetaTitle)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(e => e.Slug)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Summary)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.Content)
                .IsRequired();

            builder.Property(e => e.PublishedAt)
                .IsRequired(false);
        }
    }
}
