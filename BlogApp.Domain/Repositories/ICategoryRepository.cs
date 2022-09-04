using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
