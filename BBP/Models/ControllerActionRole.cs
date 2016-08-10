using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{
    public class ControllerActionRole : IKeyID
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 对应的ControllerAction编号
        /// </summary>
        public virtual ControllerAction ControllerAction{ get; set; }

        /// <summary>
        /// 对应的角色编号
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// IsAllowed表示包含RoleId的用户是否有权限访问ControllerActioId
        /// </summary>
        public bool IsAllowed { get; set; }

        /// <summary>
        /// 所使用的视图
        /// </summary>
        public String ViewName { get; set; }
    }
}