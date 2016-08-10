using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{
    /// <summary>
    /// 被考核人
    /// </summary>
    public class Examinee:IKeyID
    {
        [Key]
        public int ID { get; set; }

        public String Name
        {
            get
            {
                AttrValue extattr = this.ExtAttrs.FirstOrDefault(t => t.EtAttr.AttrName == "Name".ToLower());
                if (extattr != null)
                    return extattr.ExtAttrValue;
                else
                    return "";
            }
            
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public virtual ExamineeType ExamineeType { get; set; }

        /// <summary>
        /// 扩展属性
        /// </summary>
        public virtual ICollection<AttrValue> ExtAttrs { get; set; }
    }

    public class AttrValue : IKeyID
    {
        [Key]
        public int ID { get; set; }

        public virtual ETAttr EtAttr {get;set;}

        public String ExtAttrValue { get; set; }

        public virtual Examinee Examinee { get; set; }
    }
}