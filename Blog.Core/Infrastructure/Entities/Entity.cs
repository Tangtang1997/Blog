namespace Blog.Core.Infrastructure.Entities
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}