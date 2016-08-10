using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Util;

namespace BBP.Controllers
{
    [UserAuthorize]
    [ActionFillters]
    public class BaseController : Controller
    {

        #region 实体上下文

        public BaseContext DB
        {
            get
            {
                HttpContextBase context = new HttpContextWrapper(System.Web.HttpContext.Current);
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains("__BaseContext"))
                {
                    context.Items["__BaseContext"] = new BaseContext();
                }
                return context.Items["__BaseContext"] as BaseContext;
            }
        }

        #endregion


    }
}
