using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Category>> GetByIdsAsync(int[] ids, CancellationToken cancellation = default)
        {
            return await DbSet
                .Where(c => ids.Contains(c.Id))
                .ToListAsync(cancellationToken: cancellation);
        }
    }
}
