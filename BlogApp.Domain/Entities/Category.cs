using BlogApp.Domain.Commons;

namespace BlogApp.Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string Content { get; set; } = null!;

        public int? ParentId { get; set; }
        public Category? Parent { get; set; }

        public IEnumerable<Post> Posts { get; set; } = Enumerable.Empty<Post>();
    }
}
