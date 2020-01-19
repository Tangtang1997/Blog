namespace Blog.Core.Infrastructure.DomainEntities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
} 