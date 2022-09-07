using BlogApp.Application.DTOs;
using BlogApp.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Queries.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly BlogAppDbContext _dbContext;

        public GetCategoriesQueryHandler(BlogAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var queryOptions = new CategoryDto.QueryOptions()
                .SetIncludeChilds();

            return await _dbContext.Categories
                .Where(c => c.SoftDeleted == false && c.ParentId == null)
                .Include(c => c.Childs)
                .Select(c => c.AsDto(queryOptions))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
