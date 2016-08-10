using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Util;

namespace BBP.Controllers
{
    public class RepairDetailController : BaseController
    {
        //
        // GET: /RepairDetail/

        public ActionResult Index()
        {
            return View(DB.RepairDetails.ToList());
        }

        //
        // GET: /RepairDetail/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /RepairDetail/Create

        public ActionResult Create()
        {
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);
            //if (currentUser.Powers.Where(p=>p.ID==1 ||p.ID==2).Count()>0)
                ViewData["Users"] = DB.Users.Where(currentUser).ToList();
            return View();
        }

        //
        // POST: /RepairDetail/Create

        [HttpPost]
        public ActionResult Create(RepairDetail r)
        {
            r.Order = DB.Orders.Where(o => o.OrderNo == r.Order.OrderNo).FirstOrDefault<Order>();
            r.Engineer = DB.Users.Where(u => u.ID == r.Engineer.ID).FirstOrDefault<User>();
            //if (ModelState.IsValid)
            //{
            DB.RepairDetails.Add(r);
            DB.SaveChanges();
            return RedirectToAction("Index");
            // }

            // return View(r);

        }

        //
        // GET: /RepairDetail/Edit/5

        public ActionResult Edit(int id)
        {
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);
            //if (currentUser.Powers.Where(p => p.ID == 1 || p.ID == 2).Count() > 0)
                ViewData["Users"] = DB.Users.Where(currentUser).ToList();
            return View(DB.RepairDetails.Find(id));
        }

        //
        // POST: /RepairDetail/Edit/5

        [HttpPost]
        public ActionResult Edit(RepairDetail r)
        {
            r.Order = DB.Orders.Where(o => o.OrderNo == r.Order.OrderNo).FirstOrDefault<Order>();
            r.Engineer = DB.Users.Where(u => u.ID == r.Engineer.ID).FirstOrDefault<User>();

            //if (ModelState.IsValid)
            //{
            DB.Entry(r).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("Index");
            //}

            // return View(r);

        }

        //
        // GET: /RepairDetail/Delete/5

        public ActionResult Delete(int id)
        {
            DB.RepairDetails.Remove(DB.RepairDetails.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /RepairDetail/Delete/5

        [HttpPost]
        public ActionResult Delete(RepairDetail r)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET : /RepairDetail/Add
        /// <summary>
        /// Create detail from order page
        /// </summary>
        /// <param name="id">OrderId</param>
        /// <returns></returns>

        public ActionResult Add(int id, String returnAction)
        {
            User currentUser = Session["CurrentUser"] as User;
            ViewData["returnAction"] = returnAction;
            ViewData["Users"] = DB.Users.Where(currentUser).ToList();
            return View(DB.Orders.Find(id));
        }

        //POST /RepairDtail/Add
        [HttpPost]
        public ActionResult add(RepairDetail r, User Engineer, String returnAction)
        {
            r.Order = DB.Orders.Where(o => o.OrderNo == r.Order.OrderNo).FirstOrDefault<Order>();
            r.Engineer = DB.Users.Where(u => u.ID.Equals(Engineer.ID)).FirstOrDefault<User>();
            //if (ModelState.IsValid)
            //{
            DB.RepairDetails.Add(r);
            DB.SaveChanges();
            return RedirectToAction(returnAction, "Order", new { id = r.Order.ID });
        }
    }
}
