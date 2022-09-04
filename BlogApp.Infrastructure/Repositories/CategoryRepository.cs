using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;

namespace BlogApp.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
