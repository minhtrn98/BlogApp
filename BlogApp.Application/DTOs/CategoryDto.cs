using BlogApp.Domain.Entities;

namespace BlogApp.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string Content { get; set; } = null!;

        public IEnumerable<CategoryDto> Childs { get; set; } = Enumerable.Empty<CategoryDto>();
    }
}
