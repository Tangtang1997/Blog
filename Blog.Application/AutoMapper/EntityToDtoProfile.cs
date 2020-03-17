using AutoMapper;
using Blog.Application.Services.Students.Dto;
using Blog.Core.Students;

namespace Blog.Application.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        /// <summary>
        /// 创建关系映射 Entity->Dto
        /// </summary>
        public EntityToDtoProfile()
        {
            CreateMap<Student, StudentDto>();
        }
    }
}
