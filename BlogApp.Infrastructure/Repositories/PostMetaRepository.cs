using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;

namespace BlogApp.Infrastructure.Repositories
{
    public class PostMetaRepository : Repository<PostMeta, int>, IPostMetaRepository
    {
        public PostMetaRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
