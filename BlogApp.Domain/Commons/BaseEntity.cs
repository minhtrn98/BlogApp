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
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }

    public abstract class BaseEntity<TKey> : IEntityKey<TKey>, IAuditEntity, ISoftDelete
    {
        public TKey Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool SoftDeleted { get; set; }
    }
}
