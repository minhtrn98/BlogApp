using BlogApp.Domain.Commons;

namespace BlogApp.Domain.Entities
{
    public class Post : BaseEntity<int>
    {
        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string? Summary { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; } = null!;

        public virtual IEnumerable<PostMeta>? PostMetaes { get; set; }
        public virtual IEnumerable<PostComment>? PostComments { get; set; }
        public virtual IEnumerable<Tag>? Tags { get; set; }
        public virtual IEnumerable<Category>? Categories { get; set; }
    }
}
