using BlogApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlogApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogAppDbContext _dbContext;
        private IDbContextTransaction? _dbContextTransaction;

        private ICategoryRepository? _category;
        private IPostCommentRepository? _postComment;
        private IPostMetaRepository? _postMeta;
        private IPostRepository? _post;
        private ITagRepository? _tag;

        public UnitOfWork(BlogAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository Category => _category ??= new CategoryRepository(_dbContext);
        public IPostCommentRepository PostComment => _postComment ??= new PostCommentRepository(_dbContext);
        public IPostMetaRepository PostMeta => _postMeta ??= new PostMetaRepository(_dbContext);
        public IPostRepository Post => _post ??= new PostRepository(_dbContext);
        public ITagRepository Tag => _tag ??= new TagRepository(_dbContext);

        public async Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _dbContextTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            return _dbContextTransaction;
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_dbContextTransaction != null)
            {
                await _dbContextTransaction.CommitAsync(cancellationToken);
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
