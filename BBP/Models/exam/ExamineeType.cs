using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{
    /// <summary>
    /// 被考核人类型
    /// </summary>
    public class ExamineeType:IKeyID
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        [StringLength(100)]
        public string TypeName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortBy { get; set; }

        /// <summary>
        /// 扩展属性
        /// </summary>
        public virtual ICollection<ETAttr> ExtAttrs { get; set; }
    }
    public class ETAttr : IKeyID
    {
        [Key]
        public int ID { get; set; }

        [StringLength(200)]
        public string AttrName { get; set; }

        [StringLength(500)]
        public string AttrText { get; set; }

        public string AttrValue { get; set; }

        public int SortBy { get; set; }

        public virtual ValueType ValueType { get; set; }

        public virtual ExamineeType ExamineeType { get; set; }

    }
}