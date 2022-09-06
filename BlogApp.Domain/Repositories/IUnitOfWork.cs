namespace BlogApp.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IPostCommentRepository PostComment { get; }
        IPostMetaRepository PostMeta { get; }
        IPostRepository Post { get; }
        ITagRepository Tag { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    }
}