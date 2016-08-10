using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{

    /// <summary>
    /// 扩展属性
    /// </summary>
    public class Attrs:IKeyID
    {
        [Key]
        public int ID { get; set; }

        [StringLength(200)]
        public string AttrName { get; set; }

        [StringLength(200)]
        public string AttrValue { get; set; }


        public virtual ValueType ValueType { get; set; }

        public virtual AttrType AttrType { get; set; }
    }
}