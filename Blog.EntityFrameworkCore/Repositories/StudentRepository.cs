using Blog.Core.Infrastructure.IRepositories;
using Blog.Core.Infrastructure.Students;
using Blog.EntityFrameworkCore.EntityFrameworkCore;
using Blog.EntityFrameworkCore.Repositories.Base;

namespace Blog.EntityFrameworkCore.Repositories
{
    public class StudentRepository : RepositoryBase<Student, int>, IStudentRepository
    {
        /// <summary>
        /// 从依赖注入容器中拿到ApplicationDbContext的实例，传给父类构造函数，供父类实例化
        /// </summary>
        /// <param name="dbContext"></param>
        public StudentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}