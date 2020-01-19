using AutoMapper;

namespace Blog.Application.Infrastructure.AutoMapper
{
    /// <summary>
    /// 静态全局AutoMapper配置文件
    /// </summary>
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            //创建MapperConfiguration，提供静态方法Configure，一次加载所有层中的Profile定义
            //MapperConfiguration实例可以静态存储在一个静态字段，也可以存储在一个依赖注入容器中。一旦创建不能更改/修改
            return new MapperConfiguration(cfg =>
            {
                //领域模型->Dto  
                cfg.AddProfile(new EntityToDtoProfile());

                //Dto->领域模型  
                cfg.AddProfile(new DtoToEntityProfile());
            });
        }
    }
}