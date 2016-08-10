using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BBP
{
    public class OrderBill:IKeyID
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 费用类型
        /// </summary>
        [StringLength(10)]
        public string Type { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 经手人
        /// </summary>
        public virtual User person { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// 所属维修单
        /// </summary>
        public virtual Order Order { get; set; }
    }
}