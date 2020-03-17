using Microsoft.EntityFrameworkCore;

namespace Blog.EfCore.EntityFrameworkCore
{
    public abstract class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}