using BlogApp.Domain;
using BlogApp.Domain.Commons;
using BlogApp.Domain.Entities;
using BlogApp.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure
{
    public class BlogAppDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Post> Posts { get; set; } = default!;
        public DbSet<PostComment> PostComments { get; set; } = default!;
        public DbSet<PostMeta> PostMetas { get; set; } = default!;
        public DbSet<Tag> Tags { get; set; } = default!;

        public BlogAppDbContext(
            DbContextOptions<BlogAppDbContext> options,
            ILoggedInUserService loggedInUserService,
            IDateTimeProvider dateTimeProvider) : base(options)
        {
            _loggedInUserService = loggedInUserService;
            _dateTimeProvider = dateTimeProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogAppDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<ISoftDelete>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.Entity.SoftDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                    default:
                        break;
                }
            }
            foreach (var entry in ChangeTracker.Entries<IAuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = _dateTimeProvider.OffsetNow;
                        entry.Entity.UpdatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTimeProvider.OffsetNow;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
