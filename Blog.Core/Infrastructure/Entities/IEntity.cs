namespace Blog.Core.Infrastructure.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
} 