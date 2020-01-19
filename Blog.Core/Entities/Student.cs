using System.ComponentModel.DataAnnotations;
using Blog.Core.Entities.Base;

namespace Blog.Core.Entities
{
    public class Student : Entity<int>
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}