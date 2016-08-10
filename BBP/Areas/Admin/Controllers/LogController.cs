using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Controllers;

namespace BBP.Areas.Admin.Controllers
{
    public class LogController : AdminController
    {
        //
        // GET: /Admin/Log/

        public ActionResult Index()
        {
            return View(DB.Logs.OrderByDescending(l => l.LogTime).ToList());
        }

    }
}
