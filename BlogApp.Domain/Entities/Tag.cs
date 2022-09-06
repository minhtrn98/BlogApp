using BlogApp.Domain.Commons;

namespace BlogApp.Domain.Entities
{
    public class Tag : BaseEntity<int>
    {
        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string Content { get; set; } = null!;

        public IEnumerable<Post>? Posts { get; set; }
    }
}
