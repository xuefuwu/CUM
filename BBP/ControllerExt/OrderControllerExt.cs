using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Controllers
{
    public class OrderControllerExt:FilterAttribute,IActionFilter
    {
        Boolean doUpdate = false;
        BaseContext DB; 

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //执行action后执行这个方法 比如做操作日志
            if (doUpdate)
            {
                User currentUser = filterContext.HttpContext.Session["CurrentUser"] as User;
                if (filterContext.HttpContext.Items.Contains("__BaseContext"))
                {
                    DB = filterContext.HttpContext.Items["__BaseContext"] as BaseContext;
                }
                else
                {
                    DB = new BaseContext();
                    filterContext.HttpContext.Items["__BaseContext"] = DB;
                }
                Order db_order = DB.Orders.Find(Convert.ToInt32(filterContext.HttpContext.Request.Form["ID"]));
                DB.Entry(db_order).State = EntityState.Modified;
                db_order.Engineer = DB.Users.Find(currentUser.ID);
                DB.SaveChanges();
            }
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            //执行action前执行这个方法,比如做身份验证
            User currentUser = filterContext.HttpContext.Session["CurrentUser"] as User;
            if (filterContext.HttpContext.Items.Contains("__BaseContext"))
            {
                DB = filterContext.HttpContext.Items["__BaseContext"] as BaseContext;
            }
            else
            {
                DB = new BaseContext();
                filterContext.HttpContext.Items["__BaseContext"] = DB;
            }
            Order db_order = DB.Orders.Find(Convert.ToInt32(filterContext.HttpContext.Request.Form["ID"]));
            String postStatus = filterContext.HttpContext.Request.Form["Status"];
            if (postStatus.Equals("完修") && db_order.Status != postStatus)
            {
                doUpdate = true;
            }
        }
    }
}