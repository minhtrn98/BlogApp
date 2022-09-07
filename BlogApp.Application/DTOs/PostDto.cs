namespace BlogApp.Application.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string? Summary { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; } = null!;

        public IEnumerable<CategoryDto>? Categories { get; set; }

        public record QueryOptions(bool IncludeCategories = false)
        {
            public bool IncludeCategories { get; private set; } = IncludeCategories;

            public QueryOptions SetIncludeCategories()
            {
                IncludeCategories = true;
                return this;
            }
        }
    }
}
