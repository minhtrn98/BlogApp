using BlogApp.Domain.Commons;

namespace BlogApp.Domain.Entities
{
    public class PostComment : BaseEntity<int>
    {
        public string Title { get; set; } = null!;
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; } = null!;

        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

        public int? ParentId { get; set; }
        public PostComment? Parent { get; set; }

        public IEnumerable<PostComment>? PostComments { get; set; }
    }
}
