using BlogApp.Domain.Commons;

namespace BlogApp.Domain.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>, new()
    {
        Task<TEntity?> GetByIdAsync(TKey id);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        void Delete(TEntity entity);
    }
}
