namespace BlogApp.Domain.Commons
{
    public interface IEntityKey<TKey>
    {
        TKey Id { get; set; }
    }

    public interface ISoftDelete
    {
        bool SoftDeleted { get; set; }
    }

    public interface IAuditEntity
    {
        DateTimeOffset CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        string? UpdatedBy { get; set; }
    }

    public abstract class BaseEntity<TKey> : IEntityKey<TKey>, IAuditEntity, ISoftDelete
    {
        public TKey Id { get; set; } = default!;
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public bool SoftDeleted { get; set; }
    }
}
