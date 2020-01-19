using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Application.Services.Students.Dto;

namespace Blog.Application.Services.Students
{
    public interface IStudentService
    {
        Task<bool> AddAsync(StudentDto studentDto);

        Task<StudentDto> GetByIdAsync(int id);

        Task<List<StudentDto>> GetAllAsync();
    }
}