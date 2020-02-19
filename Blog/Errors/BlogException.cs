using System;
using System.Runtime.Serialization;

namespace Blog.Errors
{
    /// <summary>
    /// 基本异常类型
    /// </summary>
    public class BlogException:Exception
    {
        /// <summary>
        /// 创建一个新的<see cref="BlogException"/>对象。
        /// </summary>
        public BlogException()
        {
            
        }

        /// <summary>
        /// 创建一个新的<see cref="BlogException"/>对象。
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="context"></param>
        public BlogException(SerializationInfo serializationInfo,StreamingContext context)
            :base(serializationInfo,context)
        {
            
        }

        /// <summary>
        /// 创建一个新的<see cref="BlogException"/>对象。
        /// </summary>
        /// <param name="message">异常消息</param>
        public BlogException(string message)
            :base(message)
        {
            
        }

        /// <summary>
        /// 创建一个新的<see cref="BlogException"/>对象。
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="innerException">内部异常</param>
        public BlogException(string message,Exception innerException)
            :base(message,innerException)
        {
                
        }
    }
}