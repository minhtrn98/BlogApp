using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Repositories
{
    public interface IPostRepository : IRepository<Post, int>
    {
    }
}
