using Blog.Core.Infrastructure.DomainEntities;

namespace Blog.Core.Students
{
    public class Student : Entity<int>
    {
        public string Name { get; set; }

        public int? Age { get; set; } 
    }
}