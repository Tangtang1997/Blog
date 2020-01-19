using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Core.IRepositories;

namespace Blog.Application.DomainServices.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(
            IStudentRepository studentRepository
            )
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.FindByIdAsync(id);
        }

        public async Task<List<Student>> GetAllListAsync()
        {
            return await _studentRepository.FindAllListAsync();
        }

        public async Task<bool> AddAsync(Student student)
        {
            return await _studentRepository.InsertAsync(student) == 1;
        }
    }
}