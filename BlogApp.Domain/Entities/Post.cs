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

        public IEnumerable<PostMeta> PostMetas { get; set; } = Enumerable.Empty<PostMeta>();
        public IEnumerable<PostComment> PostComments { get; set; } = Enumerable.Empty<PostComment>();
        public IEnumerable<Tag> Tags { get; set; } = Enumerable.Empty<Tag>();
        public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();
    }
}
