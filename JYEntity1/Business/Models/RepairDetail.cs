using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JYManager
{
    public class RepairDetail :IKeyID
    {
        [Key]
        public int ID { set; get; }

        /// <summary>
        /// 维修内容
        /// </summary>
        [Required, StringLength(500)]
        public string RepairContent { get; set; }

        /// <summary>
        /// 修理时间
        /// </summary>
        public DateTime RepairDate { get; set; }

        /// <summary>
        /// 维修工程师
        /// </summary>
        public virtual User Engineer { get; set; }

        /// <summary>
        /// 所属维修单
        /// </summary>
        public virtual Order Order { get; set; }
    }
}