using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Repositories
{
    public interface IPostCommentRepository : IRepository<PostComment, int>
    {
    }
}
