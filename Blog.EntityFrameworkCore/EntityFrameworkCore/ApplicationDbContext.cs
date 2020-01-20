using Blog.Core.Authorization.Roles;
using Blog.Core.Authorization.Users;
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

        public virtual DbSet<Role> Role { get; set; }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Student> Student { get; set; }
    }
}