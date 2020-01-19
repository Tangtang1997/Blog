using Blog.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.DomainServices.Students
{
    public interface IStudentService
    {
        Task<Student> GetByIdAsync(int id);

        Task<List<Student>> GetAllListAsync();

        Task<bool> AddAsync(Student student);
    }
}