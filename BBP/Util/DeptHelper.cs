using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBP.Util
{
    public class DeptHelper
    {
        public static Dept getRootDept(int ID, BaseContext DB)
        {
            Dept root = DB.Depts.Find(ID);
            if (root.Parent != null)
            {
                return getRootDept(root.Parent.ID, DB);
            }
            else
            {
                return root;
            }
        }

        public static Dept getRootDept(User user, BaseContext DB)
        {
            Dept root = DB.Depts.Find(user.Dept.ID);
            if (root.Parent != null)
            {
                return getRootDept(root.Parent.ID, DB);
            }
            else
            {
                return root;
            }
        }

        public static Dept getRootDept(User user)
        {
            HttpContextBase context = new HttpContextWrapper(System.Web.HttpContext.Current);
            // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
            if (!context.Items.Contains("__BaseContext"))
            {
                context.Items["__BaseContext"] = new BaseContext();
            }
            return getRootDept(user, context.Items["__BaseContext"] as BaseContext);
        }

        public static Boolean CompareRootDept(User u1, User u2, BaseContext DB)
        {
            if (getRootDept(u1, DB) == getRootDept(u2, DB))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}