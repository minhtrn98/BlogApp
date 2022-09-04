using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;

namespace BlogApp.Infrastructure.Repositories
{
    public class PostCommentRepository : Repository<PostComment, int>, IPostCommentRepository
    {
        public PostCommentRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
