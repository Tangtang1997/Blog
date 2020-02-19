namespace Blog.Domain.Entities
{
    /// <summary>
    /// 定义基本实体类型的接口。系统中的所有实体都必须实现此接口。
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体的主键的类型</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 此实体的唯一标识符。
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// 检查这个实体是否是临时的(没有持久化到数据库，并且它没有<see cref="Id"/>)。
        /// </summary>
        /// <returns>true/false，如果这个实体是暂时的</returns>
        bool IsTransient();
    }
}