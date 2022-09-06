using BlogApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlogApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogAppDbContext _dbContext;
        private IDbContextTransaction? _dbContextTransaction;

        private ICategoryRepository? _categoryRepository;
        private IPostCommentRepository? _postCommentRepository;
        private IPostMetaRepository? _postMetaRepository;
        private IPostRepository? _postRepository;
        private ITagRepository? _tagRepository;

        public UnitOfWork(BlogAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext);
        public IPostCommentRepository PostCommentRepository => _postCommentRepository ??= new PostCommentRepository(_dbContext);
        public IPostMetaRepository PostMetaRepository => _postMetaRepository ??= new PostMetaRepository(_dbContext);
        public IPostRepository PostRepository => _postRepository ??= new PostRepository(_dbContext);
        public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_dbContext);

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
