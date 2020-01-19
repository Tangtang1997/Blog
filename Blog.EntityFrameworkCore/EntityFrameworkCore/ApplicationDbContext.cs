using Blog.Core.Students;
using Microsoft.EntityFrameworkCore;

namespace Blog.EntityFrameworkCore.EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Student> Student { get; set; }
    }
}