using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application.Services.Students.Dto;
using Blog.Core.Students;

namespace Blog.Application.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly StudentManager _studentManager;

        public StudentService(
            StudentManager studentManager,
            IMapper mapper
            )
        {
            _studentManager = studentManager;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            return await _studentManager.AddAsync(student);
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _studentManager.GetByIdAsync(id);

            return _mapper.Map<StudentDto>(student);
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _studentManager.GetAllAsync();

            return _mapper.Map<List<StudentDto>>(students);
        }
    }
}