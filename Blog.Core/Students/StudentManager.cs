using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.IRepositories;

namespace Blog.Core.Students
{
    public class StudentManager
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManager(
            IStudentRepository studentRepository
            )
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> AddAsync(Student student)
        {
            return await _studentRepository.InsertAsync(student) == 1;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.FindEntityByIdAsync(id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.FindAllListAsync();
        }
    }
}