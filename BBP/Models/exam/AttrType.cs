using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{
    /// <summary>
    /// 属性类型
    /// </summary>
    public class AttrType : IKeyID
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        [StringLength(100)]
        public string TypeName { get; set; }
    }
}