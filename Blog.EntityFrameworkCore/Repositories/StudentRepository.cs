using Blog.Core.Infrastructure.IRepositories;
using Blog.Core.Students;
using Blog.EntityFrameworkCore.EntityFrameworkCore;
using Blog.EntityFrameworkCore.Repositories.Base;

namespace Blog.EntityFrameworkCore.Repositories
{
    public class StudentRepository : RepositoryBase<Student, int>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}