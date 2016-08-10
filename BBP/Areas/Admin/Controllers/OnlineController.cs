using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Controllers;

namespace BBP.Areas.Admin.Controllers
{
    public class OnlineController : AdminController
    {
        //
        // GET: /Admin/Online/

        public ActionResult Index()
        {
            return View(DB.Onlines.ToList());
        }

    }
}
