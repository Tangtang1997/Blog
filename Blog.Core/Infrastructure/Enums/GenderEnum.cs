using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Infrastructure.Enums
{
    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum GenderEnum
    {
        [Display(Name = "男")]
        Male,

        [Display(Name = "女")]
        Female,

        [Display(Name = "未知")]
        UnKnow 
    }
}