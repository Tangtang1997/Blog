using Blog.EfCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.EntityFrameworkCore
{
    public class BlogDbContext : ApplicationDbContext
    {
        public BlogDbContext(DbContextOptions options)
            : base(options)
        {
        }
         

    }
}