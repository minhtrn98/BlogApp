using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;

namespace BlogApp.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post, int>, IPostRepository
    {
        public PostRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
