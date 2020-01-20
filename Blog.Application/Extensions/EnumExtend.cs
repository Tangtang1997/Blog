using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Blog.Application.Extensions
{
    /// <summary>
    /// 枚举扩展类
    /// </summary>
    public static class EnumExtend
    {
        /// <summary>
        /// 获取枚举的DisplayName
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string ToDisplayName(this Enum e)
        {
            var field = e.GetType().GetField(e.ToString());
            var enumName = field.GetCustomAttribute<DisplayAttribute>().GetName();
            return enumName;
        }
    }
}