using System;
using System.Runtime.Serialization;
using Blog.Errors;

namespace Blog.Domain.Entities
{
    /// <summary>
    /// 如果一个实体期望被找到但没有找到，则抛出此异常。
    /// </summary>
    public class EntityNotFoundException : BlogException
    {
        /// <summary>
        /// 实体的类型
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        /// 实体的Id
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// 创建一个新的<see cref="EntityNotFoundException"/>对象。
        /// </summary>
        public EntityNotFoundException()
        {

        }

        /// <summary>
        /// 创建一个新的<see cref="EntityNotFoundException"/>对象。
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="context"></param>
        public EntityNotFoundException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// 创建一个新的<see cref="EntityNotFoundException"/>对象。
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="id"></param>
        public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, null)
        {

        }

        /// <summary>
        /// 创建一个新的<see cref="EntityNotFoundException"/>对象。
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="id"></param>
        /// <param name="innerException"></param>
        public EntityNotFoundException(Type entityType, object id, Exception innerException)
            : base($"没有这样一个实体。实体类型:{entityType.FullName},id:{id}", innerException)
        {
            EntityType = entityType;
            Id = id;
        }

        /// <summary>
        /// 创建一个新的<see cref="EntityNotFoundException"/>对象。
        /// </summary>
        /// <param name="message"></param>
        public EntityNotFoundException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 创建一个新的<see cref="EntityNotFoundException"/>对象。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}