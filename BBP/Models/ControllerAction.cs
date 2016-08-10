using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{
    /// <summary>
    /// 控制器和Action
    /// </summary>
    public class ControllerAction : IKeyID
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(500)]
        public string Name { get; set; }

        /// <summary>
        /// IsController是指是否是controller，如果为false，
        /// 表示是action，那么controllerName字段就派上用场了
        /// </summary>
        [Required]
        public bool IsController { get; set; }

        /// <summary>
        /// 控制器名称
        /// 如果IsController为false，该项不能为空
        /// </summary>
        public string ControllName { get; set; }

        /// <summary>
        /// 是指是否允许没有权限的人访问
        /// </summary>
        public bool IsAllowedNoneRoles { get; set; }

        /// <summary>
        /// 是否允许有角色的人访问
        /// </summary>
        public bool IsAllowedAllRoles { get; set; }


        public virtual ICollection<Role> Roles { get; set; }

    }
}