using BlogApp.Application.DTOs;
using BlogApp.Domain.Entities;

namespace BlogApp.Infrastructure.Queries
{
    public static class Extensions
    {
        public static CategoryDto AsDto(this Category category)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                Content = category.Content,
                MetaTitle = category.MetaTitle,
                Slug = category.Slug,
                Title = category.Title,
                Childs = category.Childs?.Select(c => c.AsDto()) ?? Enumerable.Empty<CategoryDto>(),
            };
        }
    }
}
