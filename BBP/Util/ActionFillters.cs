using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Util
{
    public class ActionFillters : FilterAttribute, IActionFilter
    {
        BaseContext DB;
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //执行action后执行这个方法 比如做操作日志
            User currentUser = filterContext.HttpContext.Session["CurrentUser"] as User; 
            String action = filterContext.RouteData.Values["action"].ToString();
            String controller = filterContext.RouteData.Values["controller"].ToString();
            if (filterContext.HttpContext.Items.Contains("__BaseContext"))
            {
                DB = filterContext.HttpContext.Items["__BaseContext"] as BaseContext;
            }
            else
            {
                DB = new BaseContext();
            }
            if (controller.Equals("Account"))
            {
                return;
            } 
            // 用户为空，跳转到登陆页
            if (currentUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Area = "", Controller = "Account", Action = "LogOn" }));
                return;
            }

            DB.Logs.Add(new Log() { Level = "Operation", Logger = currentUser.ChineseName + "[" + currentUser.Name + "]", Message = "Operated on :" + controller + "/" + action, LogTime = DateTime.Now });
            DB.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //执行action前执行这个方法,比如做身份验证
        }
    }
}