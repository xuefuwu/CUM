using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{
    /// <summary>
    /// 任务
    /// </summary>
    public class Task:IKeyID
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 派发的维修单
        /// </summary>
        [Required]
        public Order Order { get; set; }

        /// <summary>
        /// 维修工程师
        /// </summary>
        [Required]
        public User User { get; set; }

        /// <summary>
        /// 派发时间
        /// </summary>
        [Required]
        public DateTime Created { get; set; }
    }
}