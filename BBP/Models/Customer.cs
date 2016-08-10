using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{
    /// <summary>
    /// 客户信息
    /// </summary>
    public class Customer :IKeyID
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [Required, StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Required, StringLength(100)]
        public string TeleNum { get; set; }

        /// <summary>
        /// 客户单位
        /// </summary>
        public Boolean  Business { get; set; }

        /// <summary>
        /// 客户邮箱
        /// </summary>
        [StringLength(100)]
        public String Email { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public virtual User Creator { get; set; }
        /// <summary>
        /// 客户维修单
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}