using Blog.Core.Entities;
using Blog.Core.IRepositories;
using Blog.Infrastructure.EntityFrameworkCore;
using Blog.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class StudentRepository : RepositoryBase<Student, int>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}