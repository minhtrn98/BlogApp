using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        Task<IEnumerable<Category>> GetByIdsAsync(int[] ids, CancellationToken cancellation = default);
    }
}
