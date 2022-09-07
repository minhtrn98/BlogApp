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
        public virtual Category? Parent { get; set; }

        public virtual IEnumerable<Post>? Posts { get; set; }
        public virtual IEnumerable<Category>? Childs { get; set; }
    }
}
