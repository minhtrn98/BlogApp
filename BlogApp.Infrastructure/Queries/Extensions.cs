using BlogApp.Application.DTOs;
using BlogApp.Domain.Entities;

namespace BlogApp.Infrastructure.Queries
{
    public static class Extensions
    {
        public static CategoryDto AsDto(this Category category, CategoryDto.QueryOptions queryOptions)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                Content = category.Content,
                MetaTitle = category.MetaTitle,
                Slug = category.Slug,
                Title = category.Title,
                Childs = (queryOptions.IncludeChilds && category.Childs is not null)
                    ? category.Childs.Select(c => c.AsDto(queryOptions))
                    : null,
                Posts = (queryOptions.IncludePosts && category.Posts is not null)
                    ? category.Posts.Select(p => p.AsDto(new PostDto.QueryOptions()))
                    : null
            };
        }

        public static PostDto AsDto(this Post post, PostDto.QueryOptions queryOptions)
        {
            return new PostDto()
            {
                Id = post.Id,
                Content = post.Content,
                MetaTitle = post.MetaTitle,
                Slug = post.Slug,
                Summary = post.Summary,
                Title = post.Title,
                Published = post.Published,
                PublishedAt = post.PublishedAt,
                Categories = (queryOptions.IncludeCategories && post.Categories is not null)
                    ? post.Categories.Select(c => c.AsDto(new CategoryDto.QueryOptions()))
                    : null
            };
        }
    }
}
