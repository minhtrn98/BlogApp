using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;

namespace BlogApp.Infrastructure.Repositories
{
    public class TagRepository : Repository<Tag, int>, ITagRepository
    {
        public TagRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
