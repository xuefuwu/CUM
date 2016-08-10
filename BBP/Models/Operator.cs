using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BBP
{
    public class Operator
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 强类型名称
        /// </summary>
        [Required]
        public String ClassName { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public String PropertyName { get; set; }

        /// <summary>
        /// 算法
        /// </summary>
        public String Method { get; set; }

        /// <summary>
        /// 对象值
        /// </summary>
        public String Value { get; set; }

        /// <summary>
        /// 组合关系
        /// </summary>
        public String Relation { get; set; }

        /// <summary>
        /// 用户规则
        /// </summary>
        public virtual Role Role { get; set; }
    }
}