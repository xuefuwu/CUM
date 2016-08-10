using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BBP
{
    /// <summary>
    /// 维修单
    /// </summary>
    public class Order:IKeyID
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 维修单号
        /// </summary>
        [StringLength(100)]
        public string OrderNo { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [StringLength(100)]
        public string SN { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        [StringLength(100)]
        public string MachineModel { get; set; }

        /// <summary>
        /// 设备序列号
        /// </summary>
        [StringLength(100)]
        public string MachineSN { get; set; }

        /// <summary>
        /// 故障现象
        /// </summary>
        [StringLength(500)]
        public string Fault { get; set; }

        /// <summary>
        /// 存放位置
        /// </summary>
        [StringLength(10)]
        public string Position { get; set; }

        /// <summary>
        /// 维修状态
        /// </summary>
        [StringLength(10)]
        public string Status { get; set; }

        /// <summary>
        /// 结单
        /// </summary>
        [StringLength(10)]
        public string Paid { get; set; }

        /// <summary>
        /// 保修类型
        /// </summary>
        [StringLength(10)]
        public string Guarantee { get; set; }

        /// <summary>
        /// 是否已取件
        /// </summary>
        [StringLength(10)]
        public string Receive { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// 维修单费用
        /// </summary>
        public virtual ICollection<OrderBill> Bills { get; set; }

        /// <summary>
        /// 维修情况
        /// </summary>
        public virtual ICollection<RepairDetail> Details { get; set; }

        /// <summary>
        /// 客户信息
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 记录创建人
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public virtual Dept Dept { get; set; }

        /// <summary>
        /// 完修工程师
        /// </summary>
        public virtual User Engineer { get; set; }
    }
}