using BlogApp.Domain.Commons;

namespace BlogApp.Domain.Entities
{
    public class PostMeta : BaseEntity<int>
    {
        public string Key { get; set; } = null!;
        public string? Content { get; set; }

        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
