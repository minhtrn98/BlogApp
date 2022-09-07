using BlogApp.Application.DTOs;
using MediatR;

namespace BlogApp.Application.Queries
{
    public record GetPostsQuery() : IRequest<IEnumerable<PostDto>>;
}
