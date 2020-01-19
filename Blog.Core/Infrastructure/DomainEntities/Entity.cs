namespace Blog.Core.Infrastructure.DomainEntities
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}