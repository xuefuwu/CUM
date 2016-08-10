using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Util
{
    /// <summary>
    /// 自定义AuthorizeAttribute
    /// </summary>
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private BaseContext DB
        {
            set;
            get;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.Items.Contains("__BaseContext"))
            {
                DB = new BaseContext();
                httpContext.Items["__BaseContext"] = DB;
            }
            else
            {
                DB = httpContext.Items["__BaseContext"] as BaseContext;
            }

            return base.AuthorizeCore(httpContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.Session["CurrentUser"] as User;
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            if (controller.Equals("Account"))
            {
                return;
            }
            if (filterContext.HttpContext.Items.Contains("__BaseContext"))
            {
                DB = filterContext.HttpContext.Items["__BaseContext"] as BaseContext;
            }
            else
            {
                DB = new BaseContext();
            }
            // 用户为空，跳转到登陆页
            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new {Area ="",Controller = "Account", Action = "LogOn" }));
                return;
            }
            User UsercurrentState = DB.Users.Where(u => u.Name == user.Name).FirstOrDefault<User>();

            if (!UsercurrentState.Enabled)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Area = "", Controller = "Account", Action = "LogOn" }));
                return;
            }
            var isAllowed = AuthorizeHelper.IsAllowed(user, controller, action, DB);
            if (!isAllowed)
            {
                filterContext.RequestContext.HttpContext.Response.Write("无权访问");
                filterContext.RequestContext.HttpContext.Response.End();
            }
        }

        /// <summary>
        /// 判断是否允许访问
        /// </summary>
        /// <span name="user"> </span>用户
        /// <span name="controller"> </span>控制器
        /// <span name="action"> </span>action
        /// <returns>是否允许访问</returns>
        public bool IsAllowed(User user, string controller, string action, BaseContext DB)
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


            // 选出action对应的角色 
            var actionRoles = DB.ControllerActionRoles.Where(ca => ca.ControllerAction.Name == action && ca.ControllerAction.IsController == false).ToList();

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