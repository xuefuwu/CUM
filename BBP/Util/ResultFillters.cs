using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Util
{
    public class ResultFillters : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //执行完action后跳转后执行
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //执行完action后跳转前执行
        }
    }
}