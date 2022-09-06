namespace BlogApp.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IPostCommentRepository PostCommentRepository { get; }
        IPostMetaRepository PostMetaRepository { get; }
        IPostRepository PostRepository { get; }
        ITagRepository TagRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    }
}