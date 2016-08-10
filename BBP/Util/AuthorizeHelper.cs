using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBP
{
    public class AuthorizeHelper
    {
        /// <summary>
        /// 判断是否允许访问
        /// </summary>
        /// <span name="user"> </span>用户
        /// <span name="controller"> </span>控制器
        /// <span name="action"> </span>action
        /// <returns>是否允许访问</returns>
        public static bool IsAllowed(User user, string controller, string action, BaseContext DB)
        {

            // 找controllerAction
            var controllerAction = DB.ControllerActions.Where(ca => ca.IsController == false && ca.Name == action && ca.ControllName == controller).FirstOrDefault<ControllerAction>();

            //action无记录，找controller
            if (controllerAction == null)
            {
                controllerAction = DB.ControllerActions.Where(ca => ca.IsController && ca.Name == controller).FirstOrDefault<ControllerAction>();
            }

            // 无规则
            if (controllerAction == null)
            {
                return true;
            }


            // 允许没有角色的：也就是说允许所有人，包括没有登录的用户 
            if (controllerAction.IsAllowedNoneRoles)
            {
                return true;
            }

            // 允许所有角色：只要有角色，就可以访问 
            if (controllerAction.IsAllowedAllRoles)
            {
                var roles = DB.Users.Where(u => u.ID == user.ID).FirstOrDefault<User>().Roles;
                if (roles.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //查找是否是系统管理用户
            var managerPower = user.Powers.Where(p => p.ID == 1 || p.ID == 2).ToList();
            if (managerPower.Count > 0)
            {
                return true;
            }
            // 选出action对应的角色 
            var actionRoles = DB.ControllerActionRoles.Where(ca => ca.ControllerAction.ID == controllerAction.ID).ToList();

            if (actionRoles.Count == 0)
            {
                // 角色数量为0，也就是说没有定义访问规则，默认允许访问 
                return true;
            }

            var userHavedRolesids = DB.Users.Where(ur => ur.ID == user.ID).FirstOrDefault<User>().Roles;

            // 查找禁止的角色 
            var notAllowedRoles = actionRoles.Where(r => !r.IsAllowed).Select(ca => ca.Role).ToList();
            if (notAllowedRoles.Count > 0)
            {
                foreach (Role role in notAllowedRoles)
                {
                    // 用户的角色在禁止访问列表中，不允许访问 
                    if (userHavedRolesids.Contains(role))
                    {
                        return false;
                    }
                }
            }

            // 查找允许访问的角色列表 
            var allowRoles = actionRoles.FindAll(r => r.IsAllowed).Select(ca => ca.Role).ToList();
            if (allowRoles.Count > 0)
            {
                foreach (Role roleId in allowRoles)
                {
                    // 用户的角色在访问的角色列表 
                    if (userHavedRolesids.Contains(roleId))
                    {
                        return true;
                    }
                }
            }



            // 默认禁止访问
            return false;
        }
    }
}