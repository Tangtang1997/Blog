using System.ComponentModel.DataAnnotations;
using Blog.Core.Constant.Enums;
using Blog.Domain.Entities;

namespace Blog.Core.Students
{
    /// <summary>
    /// Student表
    /// </summary>
    public class Student : Entity<int>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }
    }
}