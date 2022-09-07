namespace BlogApp.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string Content { get; set; } = null!;

        public IEnumerable<CategoryDto>? Childs { get; set; }
        public IEnumerable<PostDto>? Posts { get; set; }

        public record QueryOptions(bool IncludeChilds = false, bool IncludePosts = false)
        {
            public bool IncludeChilds { get; private set; } = IncludeChilds;
            public bool IncludePosts { get; private set; } = IncludePosts;

            public QueryOptions SetIncludeChilds()
            {
                IncludeChilds = true;
                return this;
            }

            public QueryOptions SetIncludePosts()
            {
                IncludePosts = true;
                return this;
            }
        }
    }
}
