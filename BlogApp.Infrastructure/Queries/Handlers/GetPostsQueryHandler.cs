using BlogApp.Application.DTOs;
using BlogApp.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Queries.Handlers
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, IEnumerable<PostDto>>
    {
        private readonly BlogAppDbContext _dbContext;

        public GetPostsQueryHandler(BlogAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var queryOptions = new PostDto.QueryOptions()
                .SetIncludeCategories();

            return await _dbContext.Posts
                .Where(p => p.SoftDeleted == false)
                .Include(p => p.Categories)
                .Select(p => p.AsDto(queryOptions))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
