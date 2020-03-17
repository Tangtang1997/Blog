using AutoMapper;
using Blog.Application.Services.Students.Dto;
using Blog.Core.Students;

namespace Blog.Application.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        /// <summary>
        /// 创建关系映射 Dto->Entity
        /// </summary>
        public DtoToEntityProfile()
        {
            CreateMap<StudentDto, Student>();
        }
    }
}
